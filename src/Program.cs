using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Hangfire_SQLite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseNLog();
                })
                .ConfigureHostConfiguration(configHost =>
                {
                   
                })
                .ConfigureServices((hostContext, services) => 
                {
                    services.Configure<HostOptions>(option => 
                    {
                        // Extend stop timeout, default is 5 seconds
                        option.ShutdownTimeout = System.TimeSpan.FromSeconds(10);
                    });
                })
            .UseWindowsService();
    }
}
