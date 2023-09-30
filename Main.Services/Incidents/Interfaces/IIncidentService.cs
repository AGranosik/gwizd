using Main.Services.Incidents.Models;
using Main.Infrastructure.Entities;

namespace Main.Services.Incidents.Interfaces
{
    public interface IIncidentService
    {
        Task<KnownSpieciesDto> AnalizeIncidentAsync(Stream image, CancellationToken cancellationToken);
        Task AddIncident(Incident incident, CancellationToken cancellationToken);
        Task<List<Incident>> GetAll();
        Task<Incident> GetById(Guid id);
    }
}
