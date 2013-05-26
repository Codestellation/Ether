using System;
using System.IO;
using Codestellation.Ether.Core;
using NUnit.Framework;

namespace Codestellation.Ether.Tests.Core
{
    [TestFixture]
    public class PersistentOutgoingEmailQueueTests
    {
        private PersistentOutgoingEmailQueue _queue;
        private string _filePath;

        [SetUp]
        public void Setup()
        {
            _filePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N") + ".emails");
        }

        [TearDown]
        public void Teardown()
        {
            if (File.Exists(_filePath))
                File.Delete(_filePath);
        }

        [Test]
        public void Ctor_should_restore_queue_from_file()
        {
            _queue = new PersistentOutgoingEmailQueue(_filePath);
            _queue.Enqueue(new Email());
            _queue.Dispose();

            var restored = new PersistentOutgoingEmailQueue(_filePath);
            Assert.That(restored, Is.Not.Empty);
        }

        [Test]
        public void Ctor_should_restore_empty_queue_if_file_not_exists()
        {
            _queue = new PersistentOutgoingEmailQueue(_filePath);
            Assert.That(_queue, Is.Empty);
        }

        [Test]
        public void Ctor_should_delete_file_if_restoration_successed()
        {
            _queue = new PersistentOutgoingEmailQueue(_filePath);
            _queue.Enqueue(new Email());
            _queue.Dispose();

            _queue = new PersistentOutgoingEmailQueue(_filePath);

            Assert.That(File.Exists(_filePath), Is.False);
        }

        [Test]
        public void Dispose_should_save_all_email_on_disk()
        {
            _queue = new PersistentOutgoingEmailQueue(_filePath);
            _queue.Enqueue(new Email());
            _queue.Dispose();

            Assert.That(File.Exists(_filePath), Is.True);
            Assert.That(new FileInfo(_filePath).Length, Is.GreaterThan(0));
        }
    }
}