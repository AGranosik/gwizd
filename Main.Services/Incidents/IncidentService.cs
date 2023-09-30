using Main.Infrastructure.ComputerVisionAgents;
using Main.Infrastructure.DbContext;
using Main.Infrastructure.Entities;
using Main.Services.Incidents.Interfaces;

namespace Main.Services.Incidents
{
    internal class IncidentService : IIncidentService
    {
        private readonly ICognitiveVisionAgent _cognitiveAgent;
        private readonly IncidentDbContext _incidentDbContext;

        public IncidentService(ICognitiveVisionAgent cognitiveVisionAgent, IncidentDbContext incidentDbContext)
        {
            _cognitiveAgent = cognitiveVisionAgent;
            _incidentDbContext = incidentDbContext;
        }
        public async Task<List<string>> AnalizeIncidentAsync(Stream image, CancellationToken cancellationToken)
            => await _cognitiveAgent.AnalyzeImageUrl(image);

        public async Task AddIncident(Incident incident, CancellationToken cancellationToken)
        {
           await _incidentDbContext.AddIncident(incident);
        }
    }
}
