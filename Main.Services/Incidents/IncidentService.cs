using Main.Services.Incidents.Interfaces;

namespace Main.Services.Incidents
{
    internal class IncidentService : IIncidentService
    {
        public Task AnalizeIncidentAsync(Stream image, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
