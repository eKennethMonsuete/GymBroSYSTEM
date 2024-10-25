using GymBroSERVICE.UserServices;
using GymBroSERVICE.UserServices.DTO;
using Microsoft.AspNetCore.Mvc;

namespace GymBroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service) => _service = service;

        [HttpPost("login")]
        [ProducesResponseType(typeof(LoginResultDTO), StatusCodes.Status200OK)]
        public async ValueTask<IActionResult> Login([FromBody] LoginDTO authDTO)
        {
            try
            {
                return Ok(await _service.Login(authDTO));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}