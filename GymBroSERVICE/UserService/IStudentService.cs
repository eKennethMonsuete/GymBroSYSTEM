using GymBroSERVICE.UserService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBroSERVICE.UserService
{
    public interface IStudentService
    {
        List<StudentResponseDTO> FindAll();
        StudentResponseDTO FindById(long id);     
        StudentResponseDTO Create(StudentCreateDTO teacherDto);          
        StudentResponseDTO Update(long id, StudentCreateDTO teacherDto);         
        void Delete(long id);
    }
}
