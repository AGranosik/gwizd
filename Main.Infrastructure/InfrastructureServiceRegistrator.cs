using Main.Infrastructure.ComputerVisionAgents;
using Main.Infrastructure.DbContext;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Main.Infrastructure
{
    public static class InfrastructureServiceRegistrator
    {
        public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .RegisterCognitvieAgentServices();

            CosmosClientOptions cosmosClientOptions = new()
            {
                HttpClientFactory = () =>
                {
                    HttpMessageHandler httpMessageHandler = new HttpClientHandler()
                    {
                        ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                    };

                    return new HttpClient(httpMessageHandler);
                },
                ConnectionMode = ConnectionMode.Gateway
            };
            var connectionString = configuration["ConnectionString"];
            var cosmosClient = new CosmosClient(connectionString, cosmosClientOptions);
            var database = cosmosClient.CreateDatabaseIfNotExistsAsync("IncidentCollection").Result;
            var incidentContainer = database.Database.CreateContainerIfNotExistsAsync("Incident", "/id").Result;
            services.AddSingleton(new Containers(incidentContainer.Container));
            services.AddScoped<IncidentDbContext>();

            return services;
        }
    }
}
