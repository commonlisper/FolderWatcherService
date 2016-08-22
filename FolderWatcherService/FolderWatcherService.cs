using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FolderWatcherService.Interfaces;

namespace FolderWatcherService
{
    public partial class FolderWatcherService : ServiceBase
    {
        private readonly IWatcher _fileWatcher;
        public FolderWatcherService(IWatcher fileWatcher)
        {
            InitializeComponent();

            _fileWatcher = fileWatcher;

            AutoLog = true;
            CanStop = true;
            CanPauseAndContinue = true;
        }

        protected override void OnStart(string[] args)
        {
            var loggerThread = new Thread(_fileWatcher.Start);
            loggerThread.Start();
        }

        protected override void OnStop()
        {
            _fileWatcher.Stop();
            Thread.Sleep(1000);
        }
    }
}
