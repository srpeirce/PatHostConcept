using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ExampleSubscriber
{
    public class PatHostBuilder
    {
        public PatHost Build()
        {
            return new PatHost();
        }

        public PatHostBuilder UseStartup<T>()
        {
            throw new NotImplementedException();
        }
    }
    
    public static class PatHostBuilderExtensions 
    {
        public static PatHostBuilder ConfigureLogging(this PatHostBuilder host, Action<PatHostBuilderContext, ILoggingBuilder> configureLogging)
        {
            throw new NotImplementedException();
        }
        
        public static PatHostBuilder UseAzureServiceBus(this PatHostBuilder host)
        {
            throw new NotImplementedException();
        }

        public static PatHostBuilder ConfigureAppConfiguration(this PatHostBuilder host, Action<PatHostBuilderContext, IConfigurationBuilder> configureDelegate)
        {
            throw new NotImplementedException();
        }
    }

    public class PatHostBuilderContext
    {
        public HostingEnvironment HostingEnvironment { get; set; }
    }

    public class HostingEnvironment
    {
        public string ContentRootPath { get; set; }
        public string EnvironmentName { get; set; }
    }

    public static class PatServiceCollectionExtensions
    {
        public static IServiceCollection AddPat(this IServiceCollection serviceCollection)
        {
            return serviceCollection;
        }
    }
}