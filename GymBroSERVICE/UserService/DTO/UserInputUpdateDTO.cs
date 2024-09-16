﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBroSERVICE.UserService.DTO
{
    public class UserInputUpdateDTO
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
    }
}
