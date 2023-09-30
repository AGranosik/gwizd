using Main.Controllers.Incidents.Requests;
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
    }
}
