﻿using GymBroINFRA.Enums;
using GymBroSERVICE.MeasuresService.DTO;
using GymBroSERVICE.PersonalService.DTO;
using GymBroSERVICE.WorkoutService.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBroSERVICE.StudentService.DTO
{
    public class StudentFindByIdResponseDTO
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

        public ICollection<MeasuresResponseToStudentDTO>? Measures
        {
            get; set;
        }

        public ICollection<WorkoutResponseToStudentFindById>? Workouts{get; set;}
        



    }
}
