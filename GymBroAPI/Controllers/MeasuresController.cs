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

            try
            {
                var measure = _service.FindByID(id);

                if(measure == null) return NotFound("Medida não encontrado.");


                return Ok(measure); 

            }
            catch (KeyNotFoundException ex)
            {
                // Retorna 404 Not Found com a mensagem de erro
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                // Em caso de erro inesperado, retorna 500 Internal Server Error
                return StatusCode(500, new { message = "Ocorreu um erro no servidor. Tente novamente mais tarde." });
            }
            
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
