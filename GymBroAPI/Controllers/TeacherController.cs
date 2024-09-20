using GymBroSERVICE.PersonalService;
using GymBroSERVICE.PersonalService.DTO;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TeacherController : ControllerBase
{
    private readonly IPersonalService _teacherService;

    public TeacherController(IPersonalService teacherService)
    {
        _teacherService = teacherService;
    }

    // GET: api/teacher
    [HttpGet]
    public IActionResult GetAllTeachers()
    {
        try
        {
            var teachers = _teacherService.FindAll();
            return Ok(teachers);
        }
        catch (Exception ex)
        {
            // Logging pode ser adicionado aqui
            return StatusCode(500, "Erro ao buscar professores: " + ex.Message);
        }
    }

    // GET: api/teacher/{id}
    [HttpGet("{id}")]
    public IActionResult GetTeacherById(long id)
    {
        try
        {
            var teacher = _teacherService.FindById(id);
            if (teacher == null)
                return NotFound("Professor não encontrado.");

            return Ok(teacher);
        }
        catch (KeyNotFoundException)
        {
            return NotFound("Professor não encontrado.");
        }
        catch (Exception ex)
        {
            // Logging pode ser adicionado aqui
            return StatusCode(500, "Erro ao buscar professor: " + ex.Message);
        }
    }

    // POST: api/teacher
    [HttpPost]
    public IActionResult CreateTeacher([FromBody] PersonalCreateDTO teacherDto)
    {
              
          return Ok(_teacherService.Create(teacherDto));
        
       
    }

    // PUT: api/teacher/{id}
    [HttpPut("{id}")]
    public IActionResult UpdateTeacher(long id, [FromBody] PersonalCreateDTO teacherDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var updatedTeacher = _teacherService.Update(id, teacherDto);
            if (updatedTeacher == null)
                return NotFound("Professor não encontrado.");

            return Ok(updatedTeacher);
        }
        catch (KeyNotFoundException)
        {
            return NotFound("Professor não encontrado.");
        }
        catch (Exception ex)
        {
            // Logging pode ser adicionado aqui
            return StatusCode(500, "Erro ao atualizar professor: " + ex.Message);
        }
    }

    // DELETE: api/teacher/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteTeacher(long id)
    {
        try
        {
            _teacherService.Delete(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound("Professor não encontrado.");
        }
        catch (Exception ex)
        {
            // Logging pode ser adicionado aqui
            return StatusCode(500, "Erro ao deletar professor: " + ex.Message);
        }
    }
}

