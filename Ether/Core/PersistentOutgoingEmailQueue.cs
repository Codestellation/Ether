using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Codestellation.Ether.Core
{
    public class PersistentOutgoingEmailQueue : IOutgoingEmailQueue, IDisposable
    {
        private readonly string _filePath;
        private readonly ConcurrentQueue<Email> _queue;
        private readonly XmlSerializer _serializer;

        public PersistentOutgoingEmailQueue(string filePath)
        {
            _filePath = filePath;
            _serializer = new XmlSerializer(typeof (Email[]));

            Email[] emails = LoadFromFile();
            _queue = new ConcurrentQueue<Email>(emails);
        }

        private Email[] LoadFromFile()
        {
            if (File.Exists(_filePath) == false)
            {
                return Enumerable.Empty<Email>().ToArray();
            }

            Email[] emails;
            using (var stream = new FileStream(_filePath, FileMode.Open, FileAccess.Read))
            {
                emails = (Email[])_serializer.Deserialize(stream);                
            }
            File.Delete(_filePath);
            return emails;
        }

        public void Enqueue(Email email)
        {
            _queue.Enqueue(email);
            OnEnqueued();
        }

        public event Action Enqueued;

        protected virtual void OnEnqueued()
        {
            Action handler = Enqueued;
            if (handler != null) handler();
        }

        public bool TryDequeue(out Email email)
        {
            return _queue.TryDequeue(out email);
        }

        public void Dispose()
        {
            SaveToFile();
        }

        private void SaveToFile()
        {
            using (var stream = new FileStream(_filePath, FileMode.Create, FileAccess.Write))
            {
                _serializer.Serialize(stream, _queue.ToArray());
                stream.Flush();
            }
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