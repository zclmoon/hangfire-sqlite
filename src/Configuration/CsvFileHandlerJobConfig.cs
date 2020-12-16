using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hangfire_SQLite.Configuration
{
    public class CsvFileHandlerJobConfig
    {
        public const string Section = "CsvFileHandlerJobConfig";
        public string JobCron { get; set; }
    }
}
