namespace Main.Controllers.Incidents.Requests
{
    public class AddIncidentRequest
    {
        public decimal X { get; set; }
        public decimal Y { get; set; }
        public string SpieciesCategory { get; set; }
        public string ConcreteSpiecies { get; set; }
        public string IncidentType { get; set; }
    }
}
