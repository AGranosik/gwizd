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

        public KnownSpieciesDto(string spieciesCategory, List<string> concreteSpecies)
        {
            SpieciesCategory = spieciesCategory;
            ConcreteSpecies = concreteSpecies;
            SetIncidentType();
        }
        public string SpieciesCategory { get; init; }
        public List<string> ConcreteSpecies { get; init; }
        public IncidentTypeAnlisisDto IncidentType { get; private set; }

        private void SetIncidentType()
        {
            EIncidentLevel? level = null;
            var dangerType = _dangerSpecies.FirstOrDefault(ds => ConcreteSpecies.Contains(ds.ToLower()));
            if (dangerType != null)
            {
                IncidentType = new IncidentTypeAnlisisDto
                {
                    IncidentLevel = EIncidentLevel.Danger,
                    Type = dangerType
                };
                return;
            }

            var warningType = _warningSpecies.FirstOrDefault(ws => ConcreteSpecies.Contains(ws));
            if(warningType != null)
            {
                IncidentType = new IncidentTypeAnlisisDto
                {
                    IncidentLevel = EIncidentLevel.Warning,
                    Type = warningType
                };
                return;
            }

            IncidentType = new IncidentTypeAnlisisDto
            {
                Type = ConcreteSpecies.FirstOrDefault(),
                IncidentLevel = EIncidentLevel.Information
            };
        }

    }

    public class IncidentTypeAnlisisDto
    {
        public EIncidentLevel IncidentLevel { get; set; }
        public string Type { get; set; }
    }
    public enum EIncidentLevel
    {
        Information,
        Warning,
        Danger
    }

    public enum EIncidentType
    {
        Dzik, Sarna, Kwiatek, Ptak, Widok, Pies, Kot, Wiewiorka
    }
}
