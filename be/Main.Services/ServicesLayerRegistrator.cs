using Main.Services.Incidents;
using Main.Services.Wikipedia;
using Microsoft.Extensions.DependencyInjection;

namespace Main.Services
{
    public static class ServicesLayerRegistrator
    {
        public static IServiceCollection RegisterServicesLayer(this IServiceCollection services)
        {
            services
                .RegisterIncidentServices()
                .RegisterWikipediaServices();

            services.AddHttpClient();

            return services;
        }
    }
}
