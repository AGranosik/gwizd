using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;

namespace Main.Infrastructure.ComputerVisionAgents
{
    public interface ICognitiveVisionAgent
    {
        Task<ImageAnalysis> AnalyzeImageUrl(Stream iamgeStream);
    }
}
