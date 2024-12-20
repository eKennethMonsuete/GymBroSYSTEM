﻿using Microsoft.AspNetCore.Mvc;
using GymBroSERVICE.StudentService;
using GymBroSERVICE.StudentService.DTO;
using Microsoft.AspNetCore.Authorization;
using GymBroSERVICE.StudentlService.DTO;

namespace GymBroAPI.Controllers
{
    [Route("api/[controller]")]
    //[Authorize(Roles = "STUDENT")]
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
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentService.FindAll();
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
// [ProducesResponseType(typeof(StudentFindAllResponseDTO), statusCode:200)]
        // POST: api/student
       // [AllowAnonymous]

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] StudentCreateDTO studentDto)
        {
            var result = await _studentService.Create(studentDto);
            return Ok(result);
        }

        // PUT: api/student/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(long id, [FromBody] StudentUpdateDTO studentDto)
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
