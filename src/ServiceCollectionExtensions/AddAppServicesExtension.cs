using Hangfire_SQLite.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AddAppServicesExtension
    {
        public static void AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<ICsvFileHandlerManager, CsvFileHandlerManager>();
        }
    }
}
