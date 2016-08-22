using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderWatcherService
{
    public interface IWatcher
    {
        void Start();
        void Stop();
    }
}
