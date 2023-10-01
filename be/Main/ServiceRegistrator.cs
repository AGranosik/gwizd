using Main.Infrastructure;
using Main.Services;

namespace Main
{
    public static class ServiceRegistrator
    {
        public static IServiceCollection RegisterLayersServices(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .RegisterInfrastructureServices(configuration)
                .RegisterServicesLayer();

            return services;
        }
    }
}
