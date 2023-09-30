using Main.Infrastructure.ComputerVisionAgents;
using Main.Services.Incidents.Interfaces;

namespace Main.Services.Incidents
{
    internal class IncidentService : IIncidentService
    {
        private readonly ICognitiveVisionAgent _cognitiveAgent;

        public IncidentService(ICognitiveVisionAgent cognitiveVisionAgent)
        {
            _cognitiveAgent = cognitiveVisionAgent;
        }
        public async Task<List<string>> AnalizeIncidentAsync(Stream image, CancellationToken cancellationToken)
            => await _cognitiveAgent.AnalyzeImageUrl(image);
    }
}
