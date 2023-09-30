using Main.Infrastructure.Entities;

namespace Main.Services.Incidents.Interfaces
{
    public interface IIncidentService
    {
        Task<List<string>> AnalizeIncidentAsync(Stream image, CancellationToken cancellationToken);
        Task AddIncident(Incident incident, CancellationToken cancellationToken);
    }
}
