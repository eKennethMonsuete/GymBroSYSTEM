
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
            var workout = _service.FindById(id);

            if (workout == null)
                return NotFound($"Treino com o ID {id} não foi encontrado.");

            return Ok(workout);

        }
    }
}
