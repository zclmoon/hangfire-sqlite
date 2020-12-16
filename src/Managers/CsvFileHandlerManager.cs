using Hangfire_SQLite.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hangfire_SQLite.Managers
{
    public class CsvFileHandlerManager : ICsvFileHandlerManager
    {
        private readonly AppConfiguration _appConfiguration;

        public CsvFileHandlerManager(IOptions<AppConfiguration> options)
        {
            _appConfiguration = options.Value;
        }

        public void HandleCsvFiles()
        {
            // TODO: Business Logic

            Console.WriteLine(_appConfiguration.SitePort);
        }
    }
}
