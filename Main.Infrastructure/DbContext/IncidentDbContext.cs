using Main.Infrastructure.Entities;
using Microsoft.Azure.Cosmos.Linq;
using Microsoft.Extensions.Configuration;

namespace Main.Infrastructure.DbContext
{
    public class IncidentDbContext
    {
        private readonly Containers _containers;
        private readonly IConfiguration _configuration;
        public IncidentDbContext(Containers containers, IConfiguration configuration)
        {
            _containers = containers;
            _configuration = configuration;
        }

        public async Task<List<Incident>> GetIncidents()
        {
            var query = _containers.IncidentContainer.GetItemLinqQueryable<Incident>();
            var iterator = query.ToFeedIterator();
            var results = await iterator.ReadNextAsync();
            return results.Select(c => c).ToList();
        }

        public async Task<Incident> GetIncident(int id)
        {
            var query = _containers.IncidentContainer.GetItemLinqQueryable<Incident>();
            var iterator = query.Where(c => c.Id == id).ToFeedIterator();
            var results = await iterator.ReadNextAsync();
            return results.First();
        }

        public async Task AddIncident(Incident incident)
        {
            await _containers.IncidentContainer.CreateItemAsync(incident);
        }
    }
}
