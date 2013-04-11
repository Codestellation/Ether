using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Net.Mail;
using System.Threading;
using Codestellation.Ether.Core;
using NLog;

namespace Codestellation.Ether.Transport
{
    public class SmtpClient : ISmtpClient, IDisposable
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        private readonly ConcurrentQueue<Email> _mailQueue;
        private int _alreadyRunning;
        private System.Net.Mail.SmtpClient _client;
        private volatile bool _disposed;
        private readonly ManualResetEventSlim _lastMailSent;

        public SmtpClient()
        {
            _mailQueue = new ConcurrentQueue<Email>();
            _lastMailSent = new ManualResetEventSlim(true);
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
            if (_alreadyRunning >= 1) return;

            //try to acquire exclusive "lock" for the sake of a single sending thread
            var current = Interlocked.Increment(ref _alreadyRunning);

            if (current > 1)
            {
                Interlocked.Decrement(ref _alreadyRunning);
                return;
            }

            ThreadPool.QueueUserWorkItem(SendNext);
        }

        private void SendNext(object state)
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

                var recipients = email.Recipients.Collect();

                var mail = new MailMessage(email.From, recipients, email.Subject, email.Body) { IsBodyHtml = true };

                _client.SendAsync(mail, email);
            }
            else
            {
                var alreadyStarted = Interlocked.Decrement(ref _alreadyRunning);

                if (alreadyStarted == 0 && _mailQueue.Count > 0)
                {
                    TryStart();
                }
                _lastMailSent.Set();
            }
        }

        private void OnSendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            var email = (Email)e.UserState;

            if (e.Error != null)
            {
                Log.ErrorException(string.Format("E-mail '{0}' sending failed", email.Subject), e.Error);
            }

            if (_disposed)
            {
                _lastMailSent.Set();
            }
            else
            {
                SendNext(null);
            }
        }

        public void Dispose()
        {
            InternalDispose();
            GC.SuppressFinalize(this);
        }

        ~SmtpClient()
        {
            InternalDispose();
        }

        private void InternalDispose()
        {
            _disposed = true;

            var client = _client;

            if (client == null) return;

            _client.SendAsyncCancel();

            _lastMailSent.Wait();

            _client.Dispose();
        }
    }
}