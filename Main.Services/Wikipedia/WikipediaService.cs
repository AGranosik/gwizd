using Main.Services.Wikipedia.Interfaces;
using Main.Services.Wikipedia.Model;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Main.Services.Wikipedia
{
    internal class WikipediaService : IWikipediaService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public WikipediaService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }
        public async Task<WikiViewModel> Search(string searchString)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var result = await httpClient.GetAsync(@$"https://pl.wikipedia.org/w/api.php?action=query&generator=search&gsrlimit=1&prop=pageimages%7Cextracts&exintro&explaintext&exlimit=max&format=json&gsrsearch={searchString}&pithumbsize=500");
            var resultString = await result.Content.ReadAsStringAsync();
            var resultRoot = JsonConvert.DeserializeObject<Root>(resultString);
            return new WikiViewModel
            {
                Description = resultRoot.query.pages.First().Value.extract,
                Image = resultRoot.query.pages.First().Value.thumbnail.source
            };
        }
    }
}
