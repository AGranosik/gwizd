using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Microsoft.Extensions.Configuration;

namespace Main.Infrastructure.ComputerVisionAgents
{
    internal class ComputerVisionAgent : ICognitiveVisionAgent
    {
        private readonly string _endpoint;
        private readonly string _key;
        public ComputerVisionAgent(IConfiguration configuration)
        {
            _key = configuration["VisionClient:VISION_KEY"];
            _endpoint = configuration["VisionClient:VISION_ENDPOINT"];
        }
        private ComputerVisionClient Authenticate()
        {
            ComputerVisionClient client =
              new ComputerVisionClient(new ApiKeyServiceClientCredentials(_key))
              { Endpoint = _endpoint };
            return client;
        }

        public async Task<List<string>> AnalyzeImageUrl(Stream iamgeStream)
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("ANALYZE IMAGE - URL");
            Console.WriteLine();


            var client = Authenticate();
            // Creating a list that defines the features to be extracted from the image. 

            List<VisualFeatureTypes?> features = new List<VisualFeatureTypes?>()
            {
                VisualFeatureTypes.Tags
            };
            // Analyze the URL image 
            ImageAnalysis results = await client.AnalyzeImageInStreamAsync(iamgeStream, visualFeatures: features);

            return results.Tags.Select(tag => $"{tag.Name} {tag.Confidence}").ToList();
        }
    }
}
