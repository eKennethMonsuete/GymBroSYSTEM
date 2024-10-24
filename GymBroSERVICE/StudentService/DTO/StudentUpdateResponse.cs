using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBroSERVICE.StudentService.DTO
{
    public class StudentUpdateResponse
    {
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

        public long? PesonalId
        {
            get; set;
        }
    }
}
