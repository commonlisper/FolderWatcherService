using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FolderWatcherService.Interfaces;

namespace FolderWatcherService
{
    public class FileWatcher : IWatcher
    {
        private readonly ILogger _logger;
        private readonly FileSystemWatcher _watcher;
        private bool _enabled = true;
        private readonly string _path;
        private readonly string _pathToMove;

        public FileWatcher(string path, string pathToMove, ILogger logger)
        {
            _logger = logger;
            _path = path;
            _pathToMove = pathToMove;

            _watcher = new FileSystemWatcher(_path);
            _watcher.Created += WatcherOnCreated;
            _watcher.Deleted += WatcherOnDeleted;
            _watcher.Changed += WatcherOnChanged;
            _watcher.Renamed += WatcherOnRenamed;
            _watcher.Error += WatcherOnError;
        }

        public void Start()
        {
            _watcher.EnableRaisingEvents = true;

            while (_enabled)
            {
                Thread.Sleep(1000);
            }
        }


        public void Stop()
        {
            _watcher.EnableRaisingEvents = false;
            _enabled = false;
        }

        private void WatcherOnError(object sender, ErrorEventArgs errorEventArgs)
        {
            _logger.Log($"error - {errorEventArgs.GetException().Message}");
        }

        private void WatcherOnRenamed(object sender, RenamedEventArgs renamedEventArgs)
        {
            _logger.Log($"{renamedEventArgs.OldFullPath} renamed in {renamedEventArgs.FullPath}");
        }

        private void WatcherOnChanged(object sender, FileSystemEventArgs fileSystemEventArgs)
        {
            _logger.Log($"changed {fileSystemEventArgs.FullPath}");
        }

        private void WatcherOnCreated(object sender, FileSystemEventArgs fileSystemEventArgs)
        {
            _logger.Log($"created {fileSystemEventArgs.FullPath}");

            var newPath = $"{_pathToMove}/{fileSystemEventArgs.Name}";
            File.Move(fileSystemEventArgs.FullPath, $"{newPath}");
            _logger.Log($"file = {_watcher.Path} was moved to {newPath}");
        }

        private void WatcherOnDeleted(object sender, FileSystemEventArgs fileSystemEventArgs)
        {
            _logger.Log($"deleted {fileSystemEventArgs.FullPath}");
        }
    }
}
