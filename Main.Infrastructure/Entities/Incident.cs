namespace Main.Infrastructure.Entities
{
    public class Incident
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string SpieciesCategory { get; set; }
        public string ConcreteSpiecies { get; set; }
        public string IncidentType { get; set; }
    }
}
