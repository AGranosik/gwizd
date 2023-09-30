using Main.Infrastructure.Entities;

namespace Main.Services.Incidents.Models
{
    public class KnownSpieciesDto {

        private static List<string> _dangerSpecies = new List<string>
        {
            "moose", "bear"
        };

        private static List<string> _warningSpecies = new List<string>
        {
            "snake", "bat", "reptile", "boar"
        };

        public KnownSpieciesDto(List<string> spieciesCategory, List<string> concreteSpecies)
        {
            SpieciesCategory = spieciesCategory;
            ConcreteSpecies = concreteSpecies;
            SetIncidentType();
        }
        public List<string> SpieciesCategory { get; init; }
        public List<string> ConcreteSpecies { get; init; }
        public IncidentTypeAnalisisDto IncidentType { get; private set; }

        private void SetIncidentType()
        {
            EIncidentLevel? level = null;
            var dangerType = _dangerSpecies.FirstOrDefault(ds => ConcreteSpecies.Contains(ds.ToLower()));
            if (dangerType != null)
            {
                IncidentType = new IncidentTypeAnalisisDto
                {
                    IncidentLevel = EIncidentLevel.Danger,
                    Type = dangerType
                };
                return;
            }

            var warningType = _warningSpecies.FirstOrDefault(ws => ConcreteSpecies.Contains(ws));
            if(warningType != null)
            {
                IncidentType = new IncidentTypeAnalisisDto
                {
                    IncidentLevel = EIncidentLevel.Warning,
                    Type = warningType
                };
                return;
            }

            IncidentType = new IncidentTypeAnalisisDto
            {
                Type = ConcreteSpecies.FirstOrDefault(),
                IncidentLevel = EIncidentLevel.Information
            };
        }

    }


}
