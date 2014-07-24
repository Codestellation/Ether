using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using NLog;

namespace Codestellation.Ether.Misc
{
    public class PersistentQueue : IQueue, IDisposable
    {
        private const int JournalSizeLimit = 8*1024*1024;
        private const int BufferSize = 64*1024;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private readonly Queue<object> _queue;
        private readonly string _snapshotFilePath;
        private readonly string _journalFilePath;
        private FileStream _journalFile;
        private readonly byte[] _buffer;
        private readonly BinaryFormatter _formatter;

        public bool ImmediatelyFlush = false;

        public PersistentQueue(string name, string folderPath = null)
        {
            _queue = new Queue<object>();
            _formatter = new BinaryFormatter();
            _buffer = new byte[BufferSize];

            _snapshotFilePath = ResolveFilePath(folderPath, name + ".dat");
            _journalFilePath = ResolveFilePath(folderPath, name + ".log");

            if (File.Exists(_journalFilePath)) // dirty shutdown?
            {
                Logger.Warn("Dirty shutdown detected");
                RecoveryFromJournal();
                TakeSnapshot();
                DeleteJournal();
            }
            else
            {
                RestoreFromSnapshot();
            }

            _journalFile = new FileStream(_journalFilePath, FileMode.Create, FileAccess.Write, FileShare.Read);
            _journalFile.SetLength(JournalSizeLimit);
        }
        
        public void Enqueue(object item)
        {
            lock (_queue)
            {
                _queue.Enqueue(item); // in-mem

                AppendEnqueueOp(item);
                if (_journalFile.Length > JournalSizeLimit)
                {
                    TakeSnapshot();
                    ResetJournal();
                }
            }
        }
        
        public bool TryDequeue(out object item)
        {
            lock (_queue)
            {
                if (_queue.Count == 0)
                {
                    item = null;
                    return false;
                }

                item = _queue.Dequeue();
                AppendDequeueOp();
                _journalFile.Flush(ImmediatelyFlush);
                return true;
            }
        }

        public bool IsEmpty
        {
            get
            {
                lock (_queue)
                {
                    return _queue.Count == 0;
                }
            }
        }

        public void Dispose()
        {
            Logger.Info("Disposing...");
            TakeSnapshot();
            DeleteJournal();
            Logger.Info("Disposed");
        }

        private void RestoreFromSnapshot()
        {
            if (File.Exists(_snapshotFilePath) == false)
            {
                Logger.Info("Snapshot file not found. 0 items restored");
                return;
            }

            object[] items;
            using (var dataFile = new FileStream(_snapshotFilePath, FileMode.Open, FileAccess.Read))
            {
                items = (object[])_formatter.Deserialize(dataFile);
            }
            foreach (var item in items)
            {
                _queue.Enqueue(item);
            }
            Logger.Info("Restored {0} items", _queue.Count);
        }

        private void RecoveryFromJournal()
        {
            _journalFile = new FileStream(_journalFilePath, FileMode.Open, FileAccess.Read);

            while (_journalFile.Position < _journalFile.Length)
            {
                var operation = (OperationType) _journalFile.ReadByte();
                switch (operation)
                {
                    case OperationType.Enqueue:
                    {
                        _journalFile.Read(_buffer, 0, 4);
                        int payloadSize = _buffer[0] + (_buffer[1] >> 8) + (_buffer[2] >> 16) + (_buffer[3] >> 24);

                        _journalFile.Read(_buffer, 0, payloadSize);
                        object item;
                        using (var memory = new MemoryStream(_buffer, 0, payloadSize))
                        {
                            item = _formatter.Deserialize(memory);
                        }
                        _queue.Enqueue(item);
                        break;
                    }
                    case OperationType.Dequeue:
                    {
                        _queue.Dequeue();
                        break;
                    }
                }
            }
            Logger.Info("Recovered {0} items from journal", _queue.Count);
        }

        private void AppendEnqueueOp(object mail)
        {
            const int headerSize = 5;

            int payloadSize;
            using (var memoryStream = new MemoryStream(_buffer, headerSize, BufferSize - headerSize))
            {
                _formatter.Serialize(memoryStream, mail);
                payloadSize = (int) memoryStream.Position;
            }

            // header
            _buffer[0] = (byte) OperationType.Enqueue;
            _buffer[1] = (byte) payloadSize;
            _buffer[2] = (byte) (payloadSize >> 8);
            _buffer[3] = (byte) (payloadSize >> 16);
            _buffer[4] = (byte) (payloadSize >> 24);

            _journalFile.Write(_buffer, 0, headerSize + payloadSize);
            _journalFile.Flush(ImmediatelyFlush);
        }

        private void AppendDequeueOp()
        {
            _journalFile.WriteByte((byte) OperationType.Dequeue);
            _journalFile.Flush(ImmediatelyFlush);
        }

        private void TakeSnapshot()
        {
            object[] items = _queue.ToArray();
            if (items.Length == 0)
            {
                if (File.Exists(_snapshotFilePath))
                {
                    File.Delete(_snapshotFilePath);
                }
                return;
            }

            using (var snapshotFile = new FileStream(_snapshotFilePath, FileMode.Create, FileAccess.Write))
            {
                _formatter.Serialize(snapshotFile, items);
                snapshotFile.Flush(true);
            }
            Logger.Info("Snapshot taken. {0} items saved", items.Length);
        }

        private void DeleteJournal()
        {
            _journalFile.Close();
            _journalFile.Dispose();
            File.Delete(_journalFilePath);
        }

        private void ResetJournal()
        {
            _journalFile.Close();
            _journalFile.Dispose();
            _journalFile = new FileStream(_journalFilePath, FileMode.Truncate, FileAccess.Write);
            _journalFile.SetLength(JournalSizeLimit);
        }

        private static string ResolveFilePath(string folderPath, string fileName)
        {
            return string.IsNullOrEmpty(folderPath)
                ? fileName //Path.Combine(Assembly.GetExecutingAssembly().Location, fileName)
                : Path.Combine(folderPath, fileName);
        }

        enum OperationType : byte
        {
            Enqueue = 1,
            Dequeue = 2
        }
    }
}