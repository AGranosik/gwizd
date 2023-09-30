namespace Main.Infrastructure.Entities
{
    public class Incident
    {
        public Guid id { get; set; } = Guid.NewGuid();
        public decimal X { get; set; }
        public decimal Y { get; set; }
        public string SpieciesCategory { get; set; }
        public string ConcreteSpiecies { get; set; }
        public string IncidentType { get; set; }
    }
}
