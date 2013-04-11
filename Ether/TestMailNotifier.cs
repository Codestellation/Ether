using System.Collections.Concurrent;
using NLog;

namespace Codestellation.Ether
{
    public class TestMailNotifier : IMailNotifier
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        public static TestMailNotifier Global = new TestMailNotifier();

        public ConcurrentQueue<object> Outgoing { get; private set; }

        public TestMailNotifier()
        {
            Outgoing = new ConcurrentQueue<object>();
        }

        public void Send(object mail)
        {
            Outgoing.Enqueue(mail);
            Log.Info("Email '{0}' was enqueued to outgoing queue", mail);
        }
    }
}