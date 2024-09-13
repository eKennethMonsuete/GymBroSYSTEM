using GymBroSERVICE.MeasuresService;
using GymBroSERVICE.MeasuresService.DTO;
using Microsoft.AspNetCore.Mvc;

namespace GymBroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasuresController : ControllerBase
    {
        private readonly IMeasuresService _service;

        public MeasuresController(IMeasuresService services)
        {
            _service = services;
        }

        [HttpPost]
        public IActionResult Post([FromBody] MeasuresCreateInputDTO input) => Ok(_service.Create(input));

    }
}
