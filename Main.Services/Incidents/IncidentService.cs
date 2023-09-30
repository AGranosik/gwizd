﻿using Main.Infrastructure.ComputerVisionAgents;
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

        public IncidentService(ICognitiveVisionAgent cognitiveVisionAgent)
        {
            _cognitiveAgent = cognitiveVisionAgent;
        }
        public async Task<KnownSpieciesDto> AnalizeIncidentAsync(Stream image, CancellationToken cancellationToken)
        {
            var analisys =  await _cognitiveAgent.AnalyzeImageUrl(image);
            var incidentCategory = _wildWordlKeys.FirstOrDefault(ww => analisys.Tags.Any(t => t.Name == ww));

            if (incidentCategory == null) // no idea what it may be. let user decide
                return null;

            var knownSpecies = _knownSpecies.FirstOrDefault(ks => analisys.Tags.Any(t => t.Name == ks));
            if (knownSpecies == null)
                return new KnownSpieciesDto(incidentCategory, analisys.Tags.Select(t => t.Name).ToList());

            return new KnownSpieciesDto(incidentCategory, new List<string> { knownSpecies });


        }
    }
}
