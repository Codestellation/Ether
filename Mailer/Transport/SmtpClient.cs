using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Net.Mail;
using System.Threading;
using Codestellation.Mailer.Core;
using NLog;

namespace Codestellation.Mailer.Transport
{
    public class SmtpClient : ISmtpClient, IDisposable
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        
        private readonly ConcurrentQueue<Email> _mailQueue;
        private int _alreadyRunning;
        private System.Net.Mail.SmtpClient _client;
        private volatile bool _disposed;
        private readonly ManualResetEvent _lastMailSent;

        public SmtpClient()
        {
            _mailQueue = new ConcurrentQueue<Email>();
            _lastMailSent = new ManualResetEvent(true);
        }

        public void Send(Email email)
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(GetType().FullName);
            }

            _mailQueue.Enqueue(email);

            TryStart();
        }

        private void TryStart()
        {
            if (_alreadyRunning >= 0) return;

            //try to acquire exclusive "lock" for the sake of a single sending thread
            var current = Interlocked.CompareExchange(ref _alreadyRunning, 1, 0);

            if(current > 0) return;

            ThreadPool.QueueUserWorkItem(delegate { SendNext(); });
        }

        private void SendNext()
        {
            _lastMailSent.Reset();

            Email email = null;

            if (_mailQueue.TryDequeue(out email))
            {
                if (_client == null)
                {
                    _client = new System.Net.Mail.SmtpClient();
                    _client.SendCompleted += OnSendCompleted;
                }

                var recipients = email.Recepients.Collect();

                var mail = new MailMessage(email.From, recipients, email.Subject, email.Body) {IsBodyHtml = true};

                _client.SendAsync(mail, email);
            }
            else
            {
                _lastMailSent.Set();
            }
        }

        private void OnSendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            var email = (Email) e.UserState;
 
            if (e.Error != null)
            {
                Log.ErrorException(string.Format("E-mail '{0}' sending failed", email.Subject), e.Error);
            }

            if (_disposed)
            {
                _lastMailSent.Set();
            }

            SendNext();
        }

        public void Dispose()
        {
            _disposed = true;

            var client = _client;

            if(client == null) return;

            _client.SendAsyncCancel();

            _lastMailSent.WaitOne();

            _client.Dispose();
        }
    }
}