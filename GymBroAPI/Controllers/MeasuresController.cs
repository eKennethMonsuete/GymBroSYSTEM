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

        [HttpGet]
        public IActionResult GetAllMeasures()
        {
            return Ok(_service.FindAll());
        }
        [HttpGet("{id}")]
        public IActionResult GetOneMeasuresByID(long id)
        {
            return Ok(_service.FindByID(id));
        }

        [HttpPost]
        public IActionResult SaveMeasures([FromBody] MeasuresCreateInputDTO input) => Ok(_service.Create(input));

        [HttpPut("{id}")]
        public IActionResult UpdateMeasures(long id, [FromBody] MeasuresUpdateInputDTO input)
        {
            var updatedMeasures = _service.Update(input, id);
            return Ok(updatedMeasures);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMeasure(long id)
        {
            _service.Delete(id);

            return NoContent();
        }

    }
}
