using GymBroINFRA.Enums;
using GymBroSERVICE.StudentService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBroSERVICE.PersonalService.DTO
{
    public class PersonalFindByIdResponse
    {
        public long Id
        {
            get; set;
        }
        public string Name
        {
            get; set;
        }
        public string Email
        {
            get; set;
        }
        public string LastName
        {
            get; set;
        }

        public string Phone
        {
            get; set;
        }
        public string CreatedAt
        {
            get; set;
        }

        public ICollection<StudentFindAllResponseDTO>? Students
        {
            get; set;
        }




    }


}
