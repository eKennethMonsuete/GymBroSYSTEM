using GymBroINFRA.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBroINFRA.Entity
{

   
    public class User
    {
       
        public long Id { get; set;}
                                         
        public string Name { get; set; }
              
        public string Email { get; set; }
              
        public string Password { get; set; }
              
        public string LastName { get; set; }

        public string Phone { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsActived { get; set; }

       // public string Ddd { get; set; }
              
       // public UserRole userRole { get; set; }
          


        
        
        




    }
}
