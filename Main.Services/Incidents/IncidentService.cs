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

        private readonly List<string> _wildWordlKeysPL = new List<string>()
        {
            "pies", "ssak", "zwierze", "gad", "wąż",
            "warzywo", "roślina", "owoc", "dzika przyroda", "kot"
        };

        private readonly List<string> _knownSpecies = new List<string>()
        {
            "collie", "golden retriever", "retriever", "dog", "cat",
            "moose", "deer", "common pipistrelle", "bat", "boar", "crow", "raven", "snake", "serpent", "reptile",
            "eurasian red squirrel", "squirrel", "bear", "dandelion", "bramble", "poppy", "African daisy", "cabbage"
        };

        private readonly List<string> _knownSpeciesPL = new List<string>()
        {
            "collie", "golden retriever", "retriever", "pies", "kot",
            "łoś", "jeleń", "świergotek pospolity", "nietoperz", "dzik", "wrona", "kruk", "wąż", "serpent", "gad",
            "ruda wiewiórka eurazjatycka", "wiewiórka", "niedźwiedź", "mniszek lekarski", "jeżyna", "poppy", "Afrykańska stokrotka", "kapusta"
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
            var incidentCategoryEng = _wildWordlKeys.FirstOrDefault(ww => analisys.Tags.Any(t => t.Name == ww));

            if (incidentCategoryEng == null) // no idea what it may be. let user decide
                return null;

            var incidentCategories = new List<string>
            {
               _wildWordlKeysPL[_wildWordlKeys.IndexOf(incidentCategoryEng)]
            };

            incidentCategories.AddRange(_wildWordlKeysPL.Where(ww => _wildWordlKeysPL.IndexOf(ww) != _wildWordlKeys.IndexOf(incidentCategoryEng)));

            var knownSpeciesEng = _knownSpecies.FirstOrDefault(ks => analisys.Tags.Any(t => t.Name == ks));
            if (knownSpeciesEng == null)
                return new KnownSpieciesDto(incidentCategories, analisys.Tags.Select(t => t.Name).ToList());

            var sss = new List<string>()
            {
                _knownSpeciesPL[_knownSpecies.IndexOf(knownSpeciesEng)]   
            };

            sss.AddRange(_knownSpeciesPL.Where(ks => _knownSpeciesPL.IndexOf(ks) != _knownSpecies.IndexOf(knownSpeciesEng)));

            return new KnownSpieciesDto(incidentCategories, sss);


        }
    }
}
