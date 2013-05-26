using System;
using System.Net.Mail;
using System.Threading;
using Codestellation.Ether.Core;
using NLog;

namespace Codestellation.Ether.Transport
{
    public class SmtpSender : IDisposable
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        private readonly IOutgoingEmailQueue _outgoingQueue;

        private readonly SmtpClient _smtpClient;

        private const int Busy = 1;
        private const int Idle = 0;
        private int _threadStatus;

        private const int Changed = 1;
        private const int UnChanged = 0;
        private int _queueStatus;

        private readonly ManualResetEvent _completed;
        private volatile bool _disposed;

        public SmtpSender(IOutgoingEmailQueue outgoingQueue)
            : this(outgoingQueue, new SmtpClient())
        {
        }

        public SmtpSender(IOutgoingEmailQueue outgoingQueue, SmtpClient smtpSmtpClient)
        {
            _outgoingQueue = outgoingQueue;
            _outgoingQueue.Enqueued += OnEnqueued;
            _smtpClient = smtpSmtpClient;
            _smtpClient.SendCompleted += SendCompleted;
            _completed = new ManualResetEvent(true);
            _threadStatus = Idle;
            _queueStatus = UnChanged;

            OnEnqueued(); // first run, if queue is not empty
        }

        private void OnEnqueued()
        {
            if (_disposed)
            {
                Log.Warn("OnEnqueued() called on disposed object");

                _outgoingQueue.Enqueued -= OnEnqueued;
                return;
            }

            _queueStatus = Changed; // queue changed

            if (Interlocked.CompareExchange(ref _threadStatus, Busy, Idle) == Busy)
            {
                return; // already busy
            }

            ThreadPool.QueueUserWorkItem(SafeTrySendNext);
        }

        private void SafeTrySendNext(object state)
        {
            try
            {
                TrySendNext();
            }
            catch (Exception error)
            {
                Log.ErrorException("Unexpected error", error);
            }
        }

        private void TrySendNext()
        {
            bool queueChanged;
            do
            {
                if (_disposed)
                {
                    _completed.Set();
                    return;
                }

                _queueStatus = UnChanged; // reset

                _completed.Reset();

                Email email;
                if (_outgoingQueue.TryDequeue(out email))
                {
                    MailMessage message = Create(email);
                    _smtpClient.SendAsync(message, email);
                    return;
                }

                _completed.Set(); // call before _status set
                _threadStatus = Idle;

                queueChanged = (_queueStatus == Changed);

                if (queueChanged)
                {
                    if (Interlocked.CompareExchange(ref _threadStatus, Busy, Idle) == Busy)
                    {
                        return; // already busy
                    }
                }

            } while (queueChanged);
        }


        private void SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            var email = (Email)e.UserState;

            if (e.Cancelled)
            {
                Log.Warn("Email '{0}' sending cancelled", email);
            }
            if (e.Error != null)
            {
                Log.ErrorException(string.Format("Email '{0}' sending failed", email), e.Error);
            }

            _completed.Set(); // call before 

            ThreadPool.QueueUserWorkItem(SafeTrySendNext);
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

        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }
            _disposed = true;

            _outgoingQueue.Enqueued -= OnEnqueued;

            _smtpClient.SendAsyncCancel();
            _completed.WaitOne(TimeSpan.FromSeconds(10)); //TODO: should be const

            _smtpClient.Dispose();
            _completed.Dispose();

            Log.Debug("Disposed");
        }
    }
}