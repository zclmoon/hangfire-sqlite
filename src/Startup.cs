using Hangfire;
using Hangfire.RecurringJobExtensions;
using Hangfire.Storage.SQLite;
using Hangfire_SQLite.Configuration;
using Hangfire_SQLite.Jobs;
using Hangfire_SQLite.Managers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hangfire_SQLite
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var appConfiguration = Configuration.GetSection(AppConfiguration.Section).Get<AppConfiguration>();
            var csvFileHandlerJobConfig = Configuration.GetSection(CsvFileHandlerJobConfig.Section).Get<CsvFileHandlerJobConfig>();

            services.Configure<CsvFileHandlerJobConfig>(Configuration.GetSection(CsvFileHandlerJobConfig.Section));

            services.AddScoped<ICsvFileHandlerManager, CsvFileHandlerManager>();

            services.AddHangfire(x =>
            {
                x.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSQLiteStorage(appConfiguration.SQLiteDBConn)
                .UseNLogLogProvider();

                var csvFileJob = JobsHelper.GenerateJobInfo(
                            typeof(TestCsvFileHandlerJob),
                            csvFileHandlerJobConfig.JobCron,
                            appConfiguration.TimeZoneId
                        );

                CronJob.AddOrUpdate(csvFileJob);
            });

            services.AddHangfireServer();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // by default the dashboard url is: http://localhost:4735/hangfire
            // set parameter to string.Empty then the new url is:  http://localhost:4735/
            app.UseHangfireDashboard(string.Empty);
        }
    }
}
