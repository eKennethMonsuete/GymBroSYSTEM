﻿using GymBroINFRA.Enums;
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

        public long Id { get; set; }



        public string Email { get; set; }

        public string Password { get; set; } 
        
        public bool IsActived { get; set; }

        public virtual Personal Personal { get; set; }

        public long? PersonalId { get; set; }

        public virtual Student Student { get; set; }
        public long? StudentId { get; set; }
    
       

       // public string Ddd { get; set; }
              
       // public UserRole userRole { get; set; }
          


        
        
        




    }
}
