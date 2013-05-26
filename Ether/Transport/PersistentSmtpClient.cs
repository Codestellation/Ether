using System;
using System.Collections.Concurrent;
using System.Net.Mail;
using System.Threading;
using Codestellation.Ether.Core;
using Codestellation.Ether.Persistence;
using NLog;

namespace Codestellation.Ether.Transport
{
    public class PersistentSmtpClient : ISmtpClient, IDisposable
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        private readonly IRepository _repository;
        private readonly ConcurrentQueue<Email> _outgoingQueue;
        private readonly System.Net.Mail.SmtpClient _client;
        private bool _busy;
        private readonly AutoResetEvent _lastMailSent;
        private volatile bool _disposed;

        public PersistentSmtpClient(IRepository repository)
        {
            _repository = repository;
            _outgoingQueue = new ConcurrentQueue<Email>();
            _client = new System.Net.Mail.SmtpClient();
            _client.SendCompleted += SendCompleted;
            _lastMailSent = new AutoResetEvent(true);
            _busy = false;
        }

        public void Send(Email email)
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(ToString());
            }

            _outgoingQueue.Enqueue(email);

            lock (_client)
            {
                if (_busy)
                {
                    return;
                }
                _busy = true;
            }
            TrySendNext();
        }

        private bool TrySendNext()
        {
            Email email;
            if (_outgoingQueue.TryDequeue(out email) == false)
            {
                return false;
            }

            _lastMailSent.Reset();

            MailMessage message = Create(email);
            _client.SendAsync(message, email);
            return true;
        }

        private void SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            _lastMailSent.Set();

            var email = (Email)e.UserState;
            if (e.Error != null)
            {
                Log.ErrorException(string.Format("E-mail '{0}' sending failed", email.Subject), e.Error);
            }

            while (TrySendNext())
            {
                ;
            }
            lock (_client)
            {
                _busy = TrySendNext();
            }
        }


        private static MailMessage Create(Email email)
        {
            var recipients = email.Recipients.Collect();
            return new MailMessage(email.From, recipients, email.Subject, email.Body) {IsBodyHtml = true};
        }

        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }
            _disposed = true;

            _client.SendAsyncCancel();

            _lastMailSent.WaitOne();

            _client.Dispose();
            _lastMailSent.Dispose();

            Email[] emails = _outgoingQueue.ToArray();
            _repository.Save(emails);
        }
    }
}