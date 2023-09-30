namespace Main.Infrastructure.ComputerVisionAgents
{
    public interface ICognitiveVisionAgent
    {
        Task<List<string>> AnalyzeImageUrl(Stream iamgeStream);
    }
}
