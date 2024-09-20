using GymBroSERVICE.TeacherService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBroSERVICE.TeacherService
{
    public interface IPersonalService
    {

        List<PersonalListAllResponseDTO> FindAll();


        PersonalFindByIdResponse FindById(long id);


        PersonalListAllResponseDTO Create(PersonalCreateDTO teacherDto);


        PersonalListAllResponseDTO Update(long id, PersonalCreateDTO teacherDto);


        void Delete(long id);
    }
}
