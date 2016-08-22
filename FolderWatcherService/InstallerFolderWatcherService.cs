using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace FolderWatcherService
{
    [RunInstaller(true)]
    public partial class InstallerFolderWatcherService : Installer
    {
        private readonly ServiceInstaller _installer;
        private readonly ServiceProcessInstaller _processInstaller;

        public InstallerFolderWatcherService()
        {
            InitializeComponent();

            _installer = new ServiceInstaller();
            _processInstaller = new ServiceProcessInstaller { Account = ServiceAccount.LocalSystem };

            _installer.StartType = ServiceStartMode.Manual;
            _installer.ServiceName = "FolderWatcherService";

            Installers.Add(_processInstaller);
            Installers.Add(_installer);
        }
    }
}
