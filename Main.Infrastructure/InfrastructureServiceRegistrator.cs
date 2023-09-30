using Main.Infrastructure.ComputerVisionAgents;
using Microsoft.Extensions.DependencyInjection;

namespace Main.Infrastructure
{
    public static class InfrastructureServiceRegistrator
    {
        public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services)
        {
            services
                .RegisterCognitvieAgentServices();

            return services;
        }
    }
}
