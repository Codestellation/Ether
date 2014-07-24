using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using Codestellation.Ether.Core;
using Codestellation.Ether.Mailing;
using Codestellation.Ether.Misc;
using Codestellation.Ether.Templating;
using Codestellation.Ether.Transport;
using NLog;

namespace Codestellation.Ether
{
    public class MailNotifier : IMailNotifier, IDisposable
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        private readonly string _fromAddress;
        private readonly IQueue _outgouingQueue;
        private readonly IMailingListBroker _mailingListBroker;
        private readonly IMailTemplateEngine _templateEngine;

        private readonly ConcurrentQueue<IEmailSender> _senders;
        private bool _disposed;

        public MailNotifier(string fromAddress, IQueue outgouingQueue, IMailingListBroker mailingListBroker, IMailTemplateEngine templateEngine, params IEmailSender[] emailSenders)
        {
            _fromAddress = fromAddress;
            _outgouingQueue = outgouingQueue;
            _mailingListBroker = mailingListBroker;
            _templateEngine = templateEngine;

            _senders = new ConcurrentQueue<IEmailSender>(emailSenders);
            foreach (var emailSender in emailSenders)
            {
                emailSender.Completed += SendingCompleted;
            }
        }
        
        public void Send(object mail)
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(typeof(MailNotifier).FullName);
            }

            _outgouingQueue.Enqueue(mail);

            IEmailSender sender;
            if (TryAcquire(out sender) == false) // try reserve
            {
                return; // all senders are busy
            }

            ThreadPool.QueueUserWorkItem(SendInternal, sender);
        }

        private void SendInternal(object state)
        {
            TrySendNextEmailOrReleaseSender((IEmailSender) state);
        }

        private bool TrySendNextEmailOrReleaseSender(IEmailSender sender)
        {
            object mail;

            bool nothingSend = (_outgouingQueue.TryDequeue(out mail) == false);
            if (nothingSend)
            {
                Release(sender);
                return false;
            }

            try
            {
                Email email = Create(mail);
                sender.SendAsync(email);
            }
            catch (Exception error)
            {
                Log.ErrorException("Sending failed", error);
                Release(sender); // prevent resources leak
            }
            return true;
        }
        
        private void SendingCompleted(object sender, AsyncCompletedEventArgs e)
        {
            var email = (Email)e.UserState;
            if (e.Cancelled)
            {
                Log.Warn("Email '{0}' sending cancelled", email);
            }

            Exception error = e.Error;
            if (error != null)
            {
                Log.ErrorException(string.Format("Email '{0}' sending failed", email), error);
            }

            ContinueSendingOrReleaseSender((IEmailSender) sender);
        }

        private void ContinueSendingOrReleaseSender(IEmailSender sender)
        {
            bool noJob;
            do
            {
                if (TrySendNextEmailOrReleaseSender(sender))
                {
                    return;
                }
                noJob = _outgouingQueue.IsEmpty; // double checking
            } while (noJob == false);
        }

        private bool TryAcquire(out IEmailSender sender)
        {
            return _senders.TryDequeue(out sender);
        }

        private void Release(IEmailSender sender)
        {
            _senders.Enqueue(sender);
        }

        private Email Create(object model)
        {
            Type modelType = model.GetType();
            MailView view = _templateEngine.Render(model);
            string[] recipients = _mailingListBroker.GetRecepients(modelType).ToArray(); //TODO: избавиться от лишнего выделения массива

            var email = new Email(_fromAddress,
                recipients,
                view);

            return email;
        }

        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }
            _disposed = true;
            
            Utils.Dispose(_templateEngine);
            foreach (var sender in _senders)
            {
                Utils.Dispose(sender);
            }
            Utils.Dispose(_outgouingQueue);
            Log.Debug("Disposed");
        }
    }
}