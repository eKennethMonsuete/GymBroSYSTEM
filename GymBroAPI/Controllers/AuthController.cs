using GymBroSERVICE.AuthService;
using GymBroSERVICE.AuthService.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymBroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuth _service;

        public AuthController(IAuth service)
        {
            _service = service;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthDTO authDTO)
        {
            
            var credentialsMessage = _service.Login(authDTO);

            
            if (credentialsMessage == "Credenciais corretas.")
            {
                return Ok(credentialsMessage); 
            }
            else
            {
                return Unauthorized(credentialsMessage); 
            }
        }
    }
}
