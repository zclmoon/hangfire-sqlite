using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hangfire_SQLite.Managers
{
    public interface ICsvFileHandlerManager
    {
        public void HandleCsvFiles();
    }
}
