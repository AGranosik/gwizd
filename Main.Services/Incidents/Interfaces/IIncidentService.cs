namespace Main.Services.Incidents.Interfaces
{
    internal interface IIncidentService
    {
        Task AnalizeIncidentAsync(Stream image, CancellationToken cancellationToken);
    }
}
