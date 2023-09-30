using Main.Services.Incidents.Models;

namespace Main.Services.Incidents.Interfaces
{
    public interface IIncidentService
    {
        Task<KnownSpieciesDto> AnalizeIncidentAsync(Stream image, CancellationToken cancellationToken);
    }
}
