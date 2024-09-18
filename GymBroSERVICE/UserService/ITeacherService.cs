using GymBroSERVICE.UserService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBroSERVICE.UserService
{
    public interface ITeacherService
    {
        // Retorna uma lista de todos os professores
        List<TeacherResponseDTO> FindAll();

        // Retorna um professor específico com base no ID
        TeacherResponseDTO FindById(long id);

        // Cria um novo professor
        TeacherResponseDTO Create(TeacherCreateDTO teacherDto);

        // Atualiza um professor existente
        TeacherResponseDTO Update(long id, TeacherCreateDTO teacherDto);

        // Exclui um professor
        void Delete(long id);
    }
}
