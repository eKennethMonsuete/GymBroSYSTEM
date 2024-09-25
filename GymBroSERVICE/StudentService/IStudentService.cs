using GymBroSERVICE.StudentlService.DTO;
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
        StudentFindAllResponseDTO Create(StudentCreateDTO studentDto);
        StudentFindByIdResponseDTO Update(long id, StudentUpdateDTO studentDto);
        void Delete(long id);
    }
}
