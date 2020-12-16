using Hangfire.RecurringJobExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hangfire_SQLite.Jobs
{
    public class JobsHelper
    {
        public static RecurringJobInfo GenerateJobInfo(Type type, string cron, string timeZoneId, bool enable = true)
        {
            // TimeZone Id: https://support.microsoft.com/en-us/help/973627/microsoft-time-zone-index-values
            TimeZoneInfo timeZone = TimeZoneInfo.Local;

            if (!string.IsNullOrEmpty(timeZoneId))
            {
                timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            }

            return new RecurringJobInfo()
            {
                Cron = cron,
                Method = type.GetMethod("Execute"),
                RecurringJobId = $"{type.Name}.Execute",
                TimeZone = timeZone,
                Queue = "default",
                Enable = enable
            };
        }
    }
}
