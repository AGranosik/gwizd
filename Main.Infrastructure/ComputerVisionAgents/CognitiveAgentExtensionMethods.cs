using Microsoft.Extensions.DependencyInjection;

namespace Main.Infrastructure.ComputerVisionAgents
{
    internal static class CognitiveAgentExtensionMethods
    {
        internal static IServiceCollection RegisterCognitvieAgentServices(this IServiceCollection services)
        {
            services.AddSingleton<ICognitiveVisionAgent, ComputerVisionAgent>();
            return services;
        }
    }
}
