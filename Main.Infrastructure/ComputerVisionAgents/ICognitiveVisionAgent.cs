using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;

namespace Main.Infrastructure.ComputerVisionAgents
{
    internal interface ICognitiveVisionAgent
    {
        Task<List<string>> AnalyzeImageUrl(Stream iamgeStream);
    }
}
