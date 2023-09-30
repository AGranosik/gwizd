using Microsoft.Azure.Cosmos;

namespace Main.Infrastructure.DbContext
{
    public class Containers
    {
        public Containers(Container incidentContainer)
        {
            IncidentContainer = incidentContainer;
        }
        public Container IncidentContainer { get; private set; }
    }
}
