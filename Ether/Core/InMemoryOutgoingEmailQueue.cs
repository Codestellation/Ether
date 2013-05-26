using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codestellation.Ether.Core
{
    public class InMemoryOutgoingEmailQueue : IOutgoingEmailQueue
    {
        private ConcurrentQueue<Email> _queue;
        private BlockingCollection<Email> _wrapper;

        public InMemoryOutgoingEmailQueue()
        {
            _queue = new ConcurrentQueue<Email>();
            _wrapper = new BlockingCollection<Email>(_queue);
        }

        public void Enqueue(Email email)
        {
            _wrapper.Add(email);
            OnEnqueued();
        }

        public event Action Enqueued;

        protected virtual void OnEnqueued()
        {
            Action handler = Enqueued;
            if (handler != null) 
                handler();
        }

        public bool TryDequeue(out Email email)
        {
            return _wrapper.TryTake(out email);
        }

        public Email GetNextOutgoing()
        {
            Email email;
            return _wrapper.TryTake(out email, TimeSpan.FromSeconds(3)) ? email : null;
        }

        public IEnumerator<Email> GetEnumerator()
        {
            return _queue.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}