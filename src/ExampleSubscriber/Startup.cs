using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PatHost;

namespace ExampleSubscriber
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPat(); // Maybe this is redundent and PatHostBuilder can register the mandatory types
            
            // Add all other dependencies required for application
        }
        
        // This method gets called by the runtime. Use this method to configure the Pat pipeline.
        public void Configure(IPatAppBuilder app)
        {
            // Maybe the `UseMiddleware` can act similar to ASP.net Core...
            
            app.MessagePipeline
                .UseMiddleware<RateLimiterMessageProcessingBehaviour>()
                .UseMiddleware<CircuitBreakerMessageProcessingBehaviour>()
                .UseMiddleware<MonitoringMessageProcessingBehaviour>()
                .UseMiddleware<DefaultMessageProcessingBehaviour>()
                .UseMiddleware<InvokeHandlerBehaviour>();

            app.BatchPipeline
                .UseMiddleware<RateLimiterBatchProcessingBehaviour>()
                .UseMiddleware<CircuitBreakerBatchProcessingBehaviour>()
                .UseMiddleware<MonitoringBatchProcessingBehaviour>()
                .UseMiddleware<DefaultBatchProcessingBehaviour>();
        }
    }
}