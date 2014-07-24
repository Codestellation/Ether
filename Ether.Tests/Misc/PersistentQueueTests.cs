using System;
using Codestellation.Ether.Misc;
using NUnit.Framework;

namespace Codestellation.Ether.Tests.Misc
{
    [TestFixture]
    public class PersistentQueueTests
    {
        [Test]
        public void Queue_should_be_persistent()
        {
            string name = Guid.NewGuid().ToString("N");

            using (var original = new PersistentQueue(name))
            {
                original.Enqueue("abc");
                original.Enqueue(12);
                original.Enqueue(true);
            }

            object item;
            using (var restored = new PersistentQueue(name))
            {
                Assert.That(restored.TryDequeue(out item), Is.True);
                Assert.That(item, Is.EqualTo("abc"));

                Assert.That(restored.TryDequeue(out item), Is.True);
                Assert.That(item, Is.EqualTo(12));
            }
            
            using (var restored = new PersistentQueue(name))
            {
                Assert.That(restored.TryDequeue(out item), Is.True);
                Assert.That(item, Is.EqualTo(true));
            }

            using (var restored = new PersistentQueue(name))
            {
                Assert.That(restored.TryDequeue(out item), Is.False);
                Assert.That(item, Is.Null);
            }
        }
    }
}