using System;
using System.Collections.Generic;

namespace Codestellation.Ether.Core
{
    public interface IOutgoingEmailQueue : IEnumerable<Email>
    {
        void Enqueue(Email email);

        event Action Enqueued;

        bool TryDequeue(out Email email);
    }
}