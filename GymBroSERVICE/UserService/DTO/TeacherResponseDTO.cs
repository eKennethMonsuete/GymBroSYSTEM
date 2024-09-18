using GymBroINFRA.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBroSERVICE.UserService.DTO
{
    public class TeacherResponseDTO
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
        public string Password
        {
            get; set;
        }
        public UserRole UserRole
        {
            get; set;
        }

        // Lista de estudantes que pertencem ao professor
        public ICollection<StudentResponseDTO>? Students
        {
            get; set;
        }

    }

    
}
