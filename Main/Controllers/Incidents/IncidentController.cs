﻿using Main.Controllers.Incidents.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Main.Controllers.Incidents
{
    [ApiController]
    [Route("[controller]")]
    public class IncidentController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateIncidentAsync([FromForm] IncidentCreationRequest request, CancellationToken cancellationToken)
        {
            var ss = HttpContext.Request.Form.Files;
            return null;
        }
    }
}
