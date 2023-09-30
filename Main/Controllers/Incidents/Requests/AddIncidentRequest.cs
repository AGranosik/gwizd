using Main.Infrastructure.Entities;

namespace Main.Controllers.Incidents.Requests
{
    public class AddIncidentRequest
    {
        public decimal X { get; set; }
        public decimal Y { get; set; }
        public string SpieciesCategory { get; set; }
        public List<string> ConcreteSpecies { get; set; }
        public IncidentTypeAnalisisDto IncidentType { get; set; }
    }
}
