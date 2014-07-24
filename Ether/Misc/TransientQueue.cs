using System.Collections.Concurrent;

namespace Codestellation.Ether.Misc
{
    public class TransientQueue : IQueue
    {
        private readonly ConcurrentQueue<object> _queue;

        public TransientQueue()
        {
            _queue = new ConcurrentQueue<object>();
        }

        public void Enqueue(object item)
        {
            _queue.Enqueue(item);
        }

        public bool TryDequeue(out object item)
        {
            return _queue.TryDequeue(out item);
        }

        public bool IsEmpty { get { return _queue.IsEmpty; } }
    }
}