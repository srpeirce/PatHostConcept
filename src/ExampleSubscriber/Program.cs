using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ExampleSubscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            CreatePatHost().Build().Run();
        }

        private static PatHostBuilder CreatePatHost()
        {
            return new PatHostBuilder()
                .UseAzureServiceBus() // Maybe one day we want to support others...e.g. RabbitMQ
                .UseStartup<Startup>()
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var env = hostingContext.HostingEnvironment;

                    config.SetBasePath(env.ContentRootPath)
                        .AddJsonFile(Path.Combine("Configuration", "appsettings.json"), 
                            optional: true,
                            reloadOnChange: true)
                        .AddJsonFile(Path.Combine("Configuration", $"appsettings.{env.EnvironmentName}.json"),
                            optional: true,
                            reloadOnChange: true)
                        .AddEnvironmentVariables();
                })
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddConsole();
                    logging.AddDebug();
                });
        }
    }
}