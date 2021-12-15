using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AR.BackgroundJobs.Configuration
{
    public static class ConfigurationServices
    {

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddLogging();
            return services;
        }

    }
}
