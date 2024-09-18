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
        
        List<TeacherResponseDTO> FindAll();

        
        TeacherResponseDTO FindById(long id);

        
        TeacherResponseDTO Create(TeacherCreateDTO teacherDto);

       
        TeacherResponseDTO Update(long id, TeacherCreateDTO teacherDto);

      
        void Delete(long id);
    }
}
