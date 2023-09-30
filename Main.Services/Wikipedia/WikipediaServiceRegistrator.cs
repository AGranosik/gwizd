using Main.Services.Incidents.Interfaces;
using Main.Services.Incidents;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Services.Wikipedia.Interfaces;

namespace Main.Services.Wikipedia
{
    public static class WikipediaServiceRegistrator
    {
        internal static IServiceCollection RegisterWikipediaServices(this IServiceCollection services)
        {
            services.AddScoped<IWikipediaService, WikipediaService>();

            return services;
        }
    }
}
