using GymBroSERVICE.WorkoutService;
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
    }
}
