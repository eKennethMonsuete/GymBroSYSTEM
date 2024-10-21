using GymBroSERVICE.PersonalService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBroSERVICE.PersonalService
{
    public interface IPersonalService
    {

        Task<List<PersonalListAllResponseDTO>> FindAll();


        PersonalFindByIdResponse FindById(long id);


        Task<PersonalListAllResponseDTO> Create(PersonalCreateDTO teacherDto);


        PersonalListAllResponseDTO Update(long id, PersonalUpdateDTO teacherDto);


        void Delete(long id);
    }
}
