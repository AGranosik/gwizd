using Main.Controllers.Incidents.Requests;
using Main.Infrastructure.Entities;
using Main.Services.Incidents.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Main.Controllers.Incidents
{
    [ApiController]
    [Route("[controller]")]
    public class IncidentController : ControllerBase
    {
        private readonly IIncidentService _service;

        public IncidentController(IIncidentService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AnalizePhotoForIncident([FromForm] IncidentCreationRequest request, CancellationToken cancellationToken)
        {
            return Ok(await _service.AnalizeIncidentAsync(request.Image.OpenReadStream(), cancellationToken));
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddIncident([FromBody] AddIncidentRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _service.AddIncident(new Incident
                {
                    ConcreteSpiecies = request.ConcreteSpiecies,
                    IncidentType = request.IncidentType,
                    SpieciesCategory = request.SpieciesCategory,
                    X = request.X,
                    Y = request.Y
                }, cancellationToken);
                return Ok();
            }
            catch(Exception)
            {
                throw;
            }

        }
    }
}
