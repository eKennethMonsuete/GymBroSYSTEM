using GymBroSERVICE.MeasuresService.DTO;
using GymBroSERVICE.UserService;
using GymBroSERVICE.UserService.DTO;
using Microsoft.AspNetCore.Http;
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

        //[HttpGet]
        //public IActionResult GetAllUsers()
        //{
        //    return Ok(_service.FindAll());
        //}
        //[HttpGet("{id}")]
        //public IActionResult GetOneUserByID(long id)
        //{
        //    return Ok(_service.FindByID(id));
        //}

        [HttpPost]
        public IActionResult SaveUser([FromBody] UserInputDTO input) => Ok(_service.Create(input));

        [HttpPut("{id}")]
        public IActionResult UpdateUser(long id, [FromBody] UserInputUpdateDTO input)
        {
            var updatedUser = _service.Update(input, id);
            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(long id)
        {
            _service.Delete(id);

            return NoContent();
        }

    }
}
