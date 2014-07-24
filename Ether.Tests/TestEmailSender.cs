using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Threading;
using Codestellation.Ether.Core;
using Codestellation.Ether.Transport;

namespace Codestellation.Ether.Tests
{
    class TestEmailSender : IEmailSender
    {
        private readonly BlockingCollection<Email> _wrapper;

        public TestEmailSender()
        {
            var queue = new ConcurrentQueue<Email>();
            _wrapper = new BlockingCollection<Email>(queue);
        }

        public Email GetNextOutgoing()
        {
            Email email;
            return _wrapper.TryTake(out email, TimeSpan.FromSeconds(5)) ? email : null;
        }

        public void SendAsync(Email email)
        {
            ThreadPool.QueueUserWorkItem(SendInternal, email);
        }

        private void SendInternal(object state)
        {
            var email = (Email) state;
            _wrapper.Add(email);

            var handler = Completed;
            if (handler != null)
            {
                handler(this, new AsyncCompletedEventArgs(null, false, email));
            }
        }

        public event AsyncCompletedEventHandler Completed;
    }
}