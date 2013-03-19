using System;
using System.Collections.Concurrent;
using Codestellation.Mailer.Core;

namespace Codestellation.Mailer.Transport
{
    public class TestSmtpClient : ISmtpClient
    {
        public ConcurrentQueue<Email> Outgoing { get; private set; }

        private readonly BlockingCollection<Email> _wrapper;

        public TestSmtpClient()
        {
            Outgoing = new ConcurrentQueue<Email>();
            _wrapper = new BlockingCollection<Email>(Outgoing);
        }

        public void Send(Email email)
        {
            _wrapper.Add(email);
        }

        public Email GetNextOutgoing()
        {
            return GetNextOutgoing(TimeSpan.FromSeconds(5));
        }

        public Email GetNextOutgoing(TimeSpan waitingTimeout)
        {
            Email email;
            return _wrapper.TryTake(out email, waitingTimeout) ? email : null;
        }
    }
}