using Hangfire;
using Hangfire.RecurringJobExtensions;
using Hangfire.Server;
using Hangfire_SQLite.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hangfire_SQLite.Jobs
{
    //[AutomaticRetry(Attempts = 3, DelaysInSeconds = new int[] { 5, 7, 13 })]
    [AutomaticRetry(Attempts = 0)]
    [DisableConcurrentExecution(120)]
    public class TestCsvFileHandlerJob : IRecurringJob
    {
        private readonly ICsvFileHandlerManager _csvFileHandlerManager;

        public TestCsvFileHandlerJob(ICsvFileHandlerManager csvFileHandlerManager)
        {
            _csvFileHandlerManager = csvFileHandlerManager;
        }

        public void Execute(PerformContext context)
        {
            // Execute business logic
            _csvFileHandlerManager.HandleCsvFiles();
        }
    }
}
