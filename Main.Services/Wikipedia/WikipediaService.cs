using Main.Services.Wikipedia.Interfaces;
using Microsoft.Extensions.Configuration;
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
        public async Task<string> Search(string searchString)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var result = await httpClient.GetAsync(@$"https://api.wikimedia.org/core/v1/wikipedia/pl/search/page?q={searchString}&limit=1");
            var resultString = await result.Content.ReadAsStringAsync();
            return resultString;
        }
    }
}
