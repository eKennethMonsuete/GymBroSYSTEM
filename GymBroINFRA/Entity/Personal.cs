using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBroINFRA.Entity
{

    public class Personal
    {
        public long Id
        {
            get; set;
        }

        public string Name
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

        public DateTime CreatedAt
        {
            get; set;
        }

        public bool IsActived
        {
            get; set;
        }

        public long UserId
        {
            get; set;
        }

        public virtual User User
        {
            get; set;
        }

        public virtual ICollection<Student> Students
        {
            get; set;
        }
    }
}
