namespace Main.Services.Incidents.Interfaces
{
    public interface IIncidentService
    {
        Task<List<string>> AnalizeIncidentAsync(Stream image, CancellationToken cancellationToken);
    }
}
