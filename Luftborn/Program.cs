using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Luftborn
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
      .UseSerilog()
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddJsonFile($"{Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}/repositorysetting.json", optional: false, reloadOnChange: true);
                    config.AddJsonFile($"{Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}/tokensetting.json", optional: false, reloadOnChange: true);
                })
                .UseStartup<Startup>();
    }
}
