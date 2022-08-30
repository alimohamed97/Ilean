using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.IO;
using System.Reflection;

namespace Presentation.AuthWebApi
{
    public class Program
    {

        public static void Main(string[] args)
        {

            var configuration = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json")
              .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            try
            {
                Log.Information("App Start");
                CreateWebHostBuilder(args).Build().Run();
            }
            catch (System.Exception ex)
            {
                Log.Fatal(ex, "System Error");
            }
            finally
            {
                Log.CloseAndFlush();
            }
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
