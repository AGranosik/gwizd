namespace Main.Controllers.Incidents.Requests
{
    public class IncidentCreationRequest
    {
        public string Type { get; set; }
        public string Image { get; set; }

        //not sure how to store them yet.
        public int Coordinates { get; set; }


    }
}
