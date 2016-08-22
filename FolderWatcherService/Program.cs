using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace FolderWatcherService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            var servicesToRun = new ServiceBase[]
            {
                new FolderWatcherService(new FileWatcher(
                    ConfigurationManager.AppSettings["FolderToWatch"],
                    ConfigurationManager.AppSettings["FolderToWatchCopy"],
                    new Logger($"{ConfigurationManager.AppSettings["LogPath"]}")))
            };

            ServiceBase.Run(servicesToRun);
        }
    }
}
