
using GymBroSERVICE.WorkoutService;
using GymBroSERVICE.WorkoutService.DTO.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymBroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutController : ControllerBase
    {

        private readonly IWorkoutService _service;

        public WorkoutController(IWorkoutService service)
        {
        
        _service = service;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllWorkouts()
        {
            return Ok(await _service.FindAll());
        }

        [HttpPost]
        public async Task<IActionResult> SaveWorkout([FromBody] WorkoutCreateRequest input) => Ok(await _service.Create(input));


        [HttpPut("{id}")]
        public IActionResult UpdadeWorkout(long id, [FromBody] WorkoutUpdateRequest input)
        {
            var updatedWorkout = _service.Update(input, id);
            return Ok(updatedWorkout);
        }

        [HttpGet("{id}")]
        public IActionResult GetOneWorkoutByID(long id)
        {
            try
            {
                var workout = _service.FindById(id);

                if (workout == null) return NotFound("Medida não encontrado.");

                return Ok(workout);

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
    }
}
