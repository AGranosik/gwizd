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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAll();
            return Ok(result.Where(r => r.CreationDate <= DateTime.Now.AddHours(-2))
                .OrderByDescending(r => r.CreationDate)
                .ToList());
        }

        [HttpGet("byId")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _service.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AnalizePhotoForIncident([FromBody] IncidentCreationRequest request, CancellationToken cancellationToken)
        {
            return Ok(await _service.AnalizeIncidentAsync(new MemoryStream(Convert.FromBase64String(request.Image)), cancellationToken));
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddIncident([FromBody] AddIncidentRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var incident = new Incident
                {
                    ConcreteSpecies = request.ConcreteSpecies,
                    IncidentType = request.IncidentType,
                    SpieciesCategory = request.SpieciesCategory,
                    Description = request.Description,
                    Image = request.Image,
                    X = request.X,
                    Y = request.Y,
                    CreationDate = request.CreationDate
                };

                await _service.AddIncident(incident, cancellationToken);
                return Ok(incident.id);
            }
            catch(Exception)
            {
                throw;
            }

        }
    }
}
