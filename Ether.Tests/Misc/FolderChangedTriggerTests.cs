using System;
using System.IO;
using System.Threading;
using Codestellation.Ether.Misc;
using NUnit.Framework;

namespace Codestellation.Ether.Tests.Misc
{
    [TestFixture]
    public class FolderChangedTriggerTests : ITriggerHander
    {
        private readonly static TimeSpan Timeout = TimeSpan.FromSeconds(3);

        private FolderChangedTrigger _trigger;        
        private string _folderPath;
        private string _filePath;
        readonly AutoResetEvent _folderChanged = new AutoResetEvent(false);

        [SetUp]
        public void Setup()
        {
            _folderPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N"));
            _filePath = Path.Combine(_folderPath, "test.txt");
            Directory.CreateDirectory(_folderPath);

            _trigger = new FolderChangedTrigger(_folderPath, "*.*");
            _trigger.Attach(this);
        }

        [TearDown]
        public void Teardown()
        {
            _trigger.Dispose();
            Directory.Delete(_folderPath, true);
        }

        [Test]
        public void Should_raise_event_if_new_file_created()
        {
            _trigger.Start();
            File.WriteAllText(_filePath, "This is new file!");

            bool changed = _folderChanged.WaitOne(Timeout);
            Assert.That(changed, Is.True);
        }

        [Test]
        public void Should_raise_event_if_file_changed()
        {
            File.WriteAllText(_filePath, "Initial file content.");
            _trigger.Start();
            File.AppendAllText(_filePath, "This file was changed.");

            bool changed = _folderChanged.WaitOne(Timeout);
            Assert.That(changed, Is.True);
        }

        [Test]
        public void Should_raise_event_if_file_deleted()
        {
            File.WriteAllText(_filePath, "This file should be deleted");
            _trigger.Start();
            File.Delete(_filePath);

            bool changed = _folderChanged.WaitOne(Timeout);
            Assert.That(changed, Is.True);
        }

        public void OnTrigger()
        {
            _folderChanged.Set();
        }
    }
}