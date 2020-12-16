using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hangfire_SQLite.Configuration
{
    public class AppConfiguration
    {
        public const string Section = "AppConfiguration";
        public string SQLiteDBConn { get; set; }
        public string SitePort { get; set; }
        public string TimeZoneId { get; set; }
    }
}
