using Hangfire_SQLite;
using Hangfire_SQLite.Configuration;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AddAppConfigExtension
    {
        public static void AddAppConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppConfiguration>(configuration.GetSection(AppConfiguration.Section));
            services.Configure<CsvFileHandlerJobConfig>(configuration.GetSection(CsvFileHandlerJobConfig.Section));

            services.AddHostedService<LifetimeEventsHostedService>();
        }
    }
}
