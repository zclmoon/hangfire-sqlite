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
        public string CsvFileFolder { get; set; }
        public string CsvFileDelimiter { get; set; }
        public string CsvFileSuffix { get; set; }
    }
}
