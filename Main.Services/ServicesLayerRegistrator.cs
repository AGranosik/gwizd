using Main.Services.Incidents;
using Microsoft.Extensions.DependencyInjection;

namespace Main.Services
{
    public static class ServicesLayerRegistrator
    {
        public static IServiceCollection RegisterServicesLayer(this IServiceCollection services)
        {
            services
                .RegisterIncidentServices();

            return services;
        }
    }
}
