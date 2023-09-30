using Main.Services.Incidents.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Main.Services.Incidents
{
    internal static class InicdentsServiceRegistator
    {
        internal static IServiceCollection RegisterIncidentServices(this IServiceCollection services)
        {
            services.AddScoped<IIncidentService, IncidentService>();

            return services;
        }
    }
}
