﻿using GymBroINFRA.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBroSERVICE.StudentService.DTO
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
        public string Whatsapp
        {
            get; set;
        }

        public string Ddd
        {
            get; set;
        }
        public long TeacherId
        {
            get; set;
        }  
        public UserRole UserRole
        {
            get; set;
        }  
    }
}