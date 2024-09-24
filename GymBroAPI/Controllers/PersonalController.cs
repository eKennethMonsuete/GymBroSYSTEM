using GymBroSERVICE.PersonalService;
using GymBroSERVICE.PersonalService.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Authorize(Roles = "PERSONAL")]
[Route("api/[controller]")]
public class PersonalController : ControllerBase
{
    private readonly IPersonalService _personalService;

    public PersonalController(IPersonalService personalService)
    {
        _personalService = personalService;
    }

    // GET: api/teacher
    [HttpGet]
    public IActionResult GetAllPersonals()
    {
        try
        {
            var teachers = _personalService.FindAll();
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
    public IActionResult GetPersonalById(long id)
    {
        try
        {
            var teacher = _personalService.FindById(id);
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
    [AllowAnonymous]
    [HttpPost]
    public IActionResult CreatePersonal([FromBody] PersonalCreateDTO teacherDto)
    {
              
          return Ok(_personalService.Create(teacherDto));
       
    }

    // PUT: api/teacher/{id}
    [HttpPut("{id}")]
    public IActionResult UpdatePersonal(long id, [FromBody] PersonalUpdateDTO teacherDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var updatedTeacher = _personalService.Update(id, teacherDto);
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
    public IActionResult DeletePersonal(long id)
    {
        try
        {
            _personalService.Delete(id);
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

