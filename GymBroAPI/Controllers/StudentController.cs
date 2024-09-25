using Microsoft.AspNetCore.Mvc;
using GymBroSERVICE.StudentService;
using GymBroSERVICE.StudentService.DTO;
using Microsoft.AspNetCore.Authorization;

namespace GymBroAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "STUDENT")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: api/student
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var students = _studentService.FindAll();
            return Ok(students);
        }

        // GET: api/student/{id}
        [HttpGet("{id}")]
        public IActionResult GetStudentById(long id)
        {
            try
            {
                var student = _studentService.FindById(id);
                return Ok(student);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Student not found.");
            }
        }

        // POST: api/student
        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateStudent([FromBody] StudentCreateDTO studentDto)
        {
               return  Ok(_studentService.Create(studentDto)); 
        }

        // PUT: api/student/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(long id, [FromBody] StudentCreateDTO studentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var updatedStudent = _studentService.Update(id, studentDto);
                return Ok(updatedStudent);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Student not found.");
            }
        }

        // DELETE: api/student/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(long id)
        {
            try
            {
                _studentService.Delete(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Student not found.");
            }
        }
    }
}
