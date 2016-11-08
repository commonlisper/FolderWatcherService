using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace FolderWatcherService.CUI
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<FileWatcher>(s =>
                {
                    s.ConstructUsing(name =>
                        new FileWatcher(ConfigurationManager.AppSettings["FolderToWatch"],
                            ConfigurationManager.AppSettings["FolderToWatchCopy"],
                            new Logger(ConfigurationManager.AppSettings["LogPath"])));

                    s.WhenStarted(fw => fw.Start());
                    s.WhenStopped(fw => fw.Stop());
                });

                x.RunAsLocalSystem();
            });
        }
    }
}
