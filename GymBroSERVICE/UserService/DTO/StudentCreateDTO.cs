using GymBroINFRA.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBroSERVICE.UserService.DTO
{
    public class StudentCreateDTO
    {
        public string Name
        {
            get; set;
        }
        public string Email
        {
            get; set;
        }
        public string Password
        {
            get; set;
        }
        public string LastName
        {
            get; set;
        }
        public long TeacherId
        {
            get; set;
        }  // Referência ao professor
        public UserRole UserRole
        {
            get; set;
        }  // Assumindo que o perfil seja definido
    }
}
