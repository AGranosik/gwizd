using Main.Infrastructure.ComputerVisionAgents;
using Main.Infrastructure.DbContext;
using Main.Infrastructure.Entities;
using Main.Services.Incidents.Interfaces;
using Main.Services.Incidents.Models;

namespace Main.Services.Incidents
{
    internal class IncidentService : IIncidentService
    {
        private readonly ICognitiveVisionAgent _cognitiveAgent;
        private readonly List<string> _wildWordlKeys = new List<string>()
        {
            "dog", "mammal", "animal", "reptile", "snake",
            "vegetable", "plant", "fruit", "wildlife", "cat"
        };

        private readonly List<string> _knownSpecies = new List<string>()
        {
            "collie", "golden retriever", "retriever", "dog", "cat",
            "moose", "deer", "common pipistrelle", "bat", "boar", "crow", "raven", "snake", "serpent", "reptile",
            "eurasian red squirrel", "squirrel", "bear", "dandelion", "bramble", "poppy", "African daisy", "cabbage"
        };
        private readonly IncidentDbContext _incidentDbContext;

        public IncidentService(ICognitiveVisionAgent cognitiveVisionAgent, IncidentDbContext incidentDbContext)
        {
            _cognitiveAgent = cognitiveVisionAgent;
            _incidentDbContext = incidentDbContext;
        }

        public async Task AddIncident(Incident incident, CancellationToken cancellationToken)
        {
            await _incidentDbContext.AddIncident(incident);
        }

        public async Task<List<Incident>> GetAll()
        {
            return await _incidentDbContext.GetIncidents();
        }

        public async Task<Incident> GetById(Guid id)
        {
            return await _incidentDbContext.GetIncident(id);
        }
        public async Task<KnownSpieciesDto> AnalizeIncidentAsync(Stream image, CancellationToken cancellationToken)
        {
            var analisys =  await _cognitiveAgent.AnalyzeImageUrl(image);
            var incidentCategory = _wildWordlKeys.FirstOrDefault(ww => analisys.Tags.Any(t => t.Name == ww));

            if (incidentCategory == null) // no idea what it may be. let user decide
                return null;

            var incidentCategories = new List<string>
            {
                incidentCategory
            };

            incidentCategories.AddRange(_wildWordlKeys.Where(ww => ww != incidentCategory));

            var knownSpecies = _knownSpecies.FirstOrDefault(ks => analisys.Tags.Any(t => t.Name == ks));
            if (knownSpecies == null)
                return new KnownSpieciesDto(incidentCategories, analisys.Tags.Select(t => t.Name).ToList());

            var sss = new List<string>()
            {
                knownSpecies
            };

            sss.AddRange(_knownSpecies.Where(ks => ks != knownSpecies));

            return new KnownSpieciesDto(incidentCategories, sss);


        }
    }
}
