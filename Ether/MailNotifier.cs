using System;
using System.Linq;
using System.Threading;
using Codestellation.Ether.Core;
using Codestellation.Ether.Mailing;
using Codestellation.Ether.Templating;
using NLog;

namespace Codestellation.Ether
{
    public class MailNotifier : IMailNotifier, IDisposable
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        private readonly string _fromAddress;
        private readonly IOutgoingEmailQueue _outgoingQueue;
        private readonly IMailingListBroker _mailingListBroker;
        private readonly IMailTemplateEngine _templateEngine;

        private bool _disposed;
        private readonly CountdownEvent _completed;

        public MailNotifier(string fromAddress, IOutgoingEmailQueue outgoingQueue, IMailingListBroker mailingListBroker, IMailTemplateEngine templateEngine)
        {
            if(string.IsNullOrEmpty(fromAddress))
            {
                throw new ArgumentNullException("fromAddress");
            }
            _fromAddress = fromAddress;
            _outgoingQueue = outgoingQueue;
            _mailingListBroker = mailingListBroker;
            _templateEngine = templateEngine;
            _completed = new CountdownEvent(1);
        }

        public void Send(object mail)
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(GetType().FullName);
            }
            _completed.TryAddCount(1);
            ThreadPool.QueueUserWorkItem(RenderAndSend, mail);
        }

        void RenderAndSend(object mail)
        {
            try
            {
                Type mailType = mail.GetType();
                MailView view = _templateEngine.Render(mail);
                string[] recipients = _mailingListBroker.GetRecepients(mailType).ToArray();

                var email = new Email(_fromAddress,
                                      recipients,
                                      view);

                _outgoingQueue.Enqueue(email);
            }
            catch (Exception error)
            {
                Log.ErrorException(string.Format("Email '{0}' sending failed", mail), error);
            }
            finally
            {
                _completed.Signal();
            }
        }

        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }
            _disposed = true;
            _completed.Signal();
            _completed.Wait(TimeSpan.FromSeconds(10)); //TODO: should be const
            _completed.Dispose();

            Log.Debug("Disposed");
        }
    }
}