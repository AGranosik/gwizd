using Main.Infrastructure.DbContext;
using Main.Infrastructure.Entities;

namespace Main.Services.Incidents.Interfaces
{
    public interface IIncidentService
    {
        Task<List<string>> AnalizeIncidentAsync(Stream image, CancellationToken cancellationToken);
        Task AddIncident(Incident incident, CancellationToken cancellationToken);
        Task<List<Incident>> GetAll();
        Task<Incident> GetById(Guid id);
    }
}
