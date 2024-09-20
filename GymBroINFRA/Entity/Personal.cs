using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBroINFRA.Entity
{
   
    public class Personal : User
    {



        public virtual ICollection<Student> Students
        {
            get; set;
        }
    }
}
