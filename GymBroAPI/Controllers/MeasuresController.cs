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
        public async Task<IActionResult> GetAllMeasures()
        {
            return Ok( await _service.FindAll());
        }
        [HttpGet("{id}")]
        public IActionResult GetOneMeasuresByID(long id)
        {
            return Ok(_service.FindByID(id));
        }

        [HttpPost]
        public async Task<IActionResult> SaveMeasures([FromBody] MeasuresCreateInputDTO input) => Ok( await _service.Create(input));

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
