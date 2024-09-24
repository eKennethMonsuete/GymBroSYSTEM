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

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO authDTO)
        {

            return Ok(_service.Login(authDTO));
        }
    }
}