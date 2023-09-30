namespace Main.Infrastructure.Entities
{
    public class Incident
    {
        public Guid id { get; set; } = Guid.NewGuid();
        public decimal X { get; set; }
        public decimal Y { get; set; }
        public string SpieciesCategory { get; set; }
        public List<string> ConcreteSpecies { get; set; }
        public IncidentTypeAnalisisDto IncidentType { get; set; }
    }

    public class IncidentTypeAnalisisDto
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
