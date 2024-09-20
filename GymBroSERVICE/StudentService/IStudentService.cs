using GymBroSERVICE.StudentService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBroSERVICE.StudentService
{
    public interface IStudentService
    {
        List<StudentFindAllResponseDTO> FindAll();
        StudentFindByIdResponseDTO FindById(long id);
        StudentFindAllResponseDTO Create(StudentCreateDTO teacherDto);
        StudentFindByIdResponseDTO Update(long id, StudentCreateDTO teacherDto);
        void Delete(long id);
    }
}
