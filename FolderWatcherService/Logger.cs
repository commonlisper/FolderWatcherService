using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FolderWatcherService.Interfaces;

namespace FolderWatcherService
{
    public class Logger : ILogger
    {
        private readonly string _logPath;
        private readonly object _obj;
        public Logger(string logPath)
        {
            _logPath = logPath;
            _obj = new object();
        }

        public void Log(string logMessage)
        {
            lock (_obj)
            {
                using (var sw = new StreamWriter($"{_logPath}", true))
                {
                    sw.WriteLine($"{DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss")} - {logMessage}");
                    sw.Flush();
                }
            }
        }
    }
}
