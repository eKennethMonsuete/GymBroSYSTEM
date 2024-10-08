﻿using System.ComponentModel.DataAnnotations;

namespace GymBroSERVICE.PersonalService.DTO
{
    public class PersonalCreateDTO
    {
        [Required]
        public string Name
        {
            get; set;
        }

        [Required]
        public string Email
        {
            get; set;
        }

        [Required]
        public string Password
        {
            get; set;
        }

        [Required]
        public string LastName
        {
            get; set;
        }
        [Required]
        public string Phone
        {
            get; set;
        }
    }
}
