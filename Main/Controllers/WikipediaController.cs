using Main.Services.Wikipedia.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Main.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WikipediaController : ControllerBase
    {
        private readonly IWikipediaService _wikipediaService;
        public WikipediaController(IWikipediaService wikipediaService)
        {
            _wikipediaService = wikipediaService;
        }
        [HttpGet]
        public async Task<IActionResult> Get(string searchString)
        {
            return Ok(await _wikipediaService.Search(searchString));
        }
    }
}
