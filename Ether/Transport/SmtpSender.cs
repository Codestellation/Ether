using System;
using System.ComponentModel;
using System.Net.Mail;
using System.Threading;
using Codestellation.Ether.Core;
using NLog;

namespace Codestellation.Ether.Transport
{
    public class SmtpSender : IEmailSender, IDisposable
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        private readonly SmtpClient _smtpClient;        
        private readonly ManualResetEvent _completed;
        private volatile bool _disposed;

        public SmtpSender() : this(new SmtpClient())
        {
        }

        public SmtpSender(SmtpClient smtpSmtpClient)
        {
            _smtpClient = smtpSmtpClient;
            
            _smtpClient.SendCompleted += SendCompleted;
            _completed = new ManualResetEvent(true);
        }

        public void SendAsync(Email email)
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(typeof (SmtpSender).FullName);
            }
            _completed.Reset();

            MailMessage message = Create(email);
            _smtpClient.SendAsync(message, email);
        }

        public event AsyncCompletedEventHandler Completed;

        private void SendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            OnCompleted(e);
            _completed.Set();
        }

        private static MailMessage Create(Email email)
        {
            var recipients = email.Recipients.Collect();
            return new MailMessage(email.From,
                                   recipients,
                                   email.Subject,
                                   email.Body)
                {
                    IsBodyHtml = true
                };
        }

        private void OnCompleted(AsyncCompletedEventArgs args)
        {
            var handler = Completed;
            if (handler != null)
            {
                handler(this, args);
            }
            else
            {
                Exception error = args.Error;
                if (error != null)
                {
                    Log.WarnException("Ignored exception", error);
                }
            }
        }

        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }
            _disposed = true;
            
            _smtpClient.SendAsyncCancel();
            _completed.WaitOne(TimeSpan.FromSeconds(10)); //TODO: should be const

            _smtpClient.Dispose();
            _completed.Dispose();

            Log.Debug("Disposed");
        }
    }
}