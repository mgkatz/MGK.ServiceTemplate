using MGK.Extensions;
using MGK.ServiceBase;
using MGK.ServiceBase.Constants;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.IO;

namespace MGK.ServiceTemplate.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = AppInitializer.GetConfiguration();
            Log.Logger = new LoggerConfiguration()
               .ReadFrom
               .Configuration(configuration)
               .CreateLogger();

            Log.Information(BaseResources.MessagesResources.LoggingStartUp);

            try
            {
                Log.Information(BaseResources.MessagesResources.LoggingStartUpConfiguration.Format(AppInitializer.EnvName));
                var host = CreateHostBuilder(args).Build();

                Log.Information(BaseResources.MessagesResources.LoggingStartUpWebHost.Format(configuration[AppConfigurationKeys.AppName]));
                host.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, BaseResources.MessagesResources.ErrorApplicationBrake);
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webHostBuilder => GetWebHostDefaults(webHostBuilder));

        private static IWebHostBuilder GetWebHostDefaults(IWebHostBuilder webHostBuilder)
            => webHostBuilder
                .UseKestrel()
                .UseIISIntegration()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration((hostingContext, config) => AppInitializer.SetConfigurationBuilder(config))
                .UseSerilog()
                .UseDefaultServiceProvider((context, options) => { })
                .UseStartup<Startup>();
    }
}
