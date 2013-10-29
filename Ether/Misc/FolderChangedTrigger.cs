using System;
using System.Collections.Generic;
using System.IO;

namespace Codestellation.Ether.Misc
{
    public class FolderChangedTrigger : ITrigger, IDisposable
    {
        private readonly FileSystemWatcher _watcher;
        private readonly List<ITriggerHander> _handlers;

        public FolderChangedTrigger(string folderPath, string filter)
        {
            _watcher = new FileSystemWatcher(folderPath, filter);
            _watcher.Created += OnFolderChanged;
            _watcher.Deleted += OnFolderChanged;
            _watcher.Changed += OnFolderChanged;
            _handlers = new List<ITriggerHander>();
        }

        public void Attach(ITriggerHander handler)
        {
            _handlers.Add(handler);
        }

        public void Start()
        {
            _watcher.EnableRaisingEvents = true;
        }

        public void Stop()
        {
            _watcher.EnableRaisingEvents = false;
        }

        public void Dispose()
        {
            _watcher.Dispose();
        }

        void OnFolderChanged(object sender, FileSystemEventArgs e)
        {
            foreach (var handler in _handlers)
            {
                handler.OnTrigger();
            }
        }
    }
}