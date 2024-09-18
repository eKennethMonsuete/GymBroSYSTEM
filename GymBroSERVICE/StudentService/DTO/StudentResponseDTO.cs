using GymBroINFRA.Enums;
using GymBroSERVICE.MeasuresService.DTO;
using GymBroSERVICE.TeacherService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBroSERVICE.StudentService.DTO
{
    public class StudentResponseDTO
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
        public UserRole UserRole
        {
            get; set;
        }

        // Referência ao professor
        public TeacherResponseDTO Teacher
        {
            get; set;
        }

        // Medidas do aluno
        public ICollection<MeasuresResponseDTO>? Measures
        {
            get; set;
        }

        // Treinos do aluno
        // public ICollection<WorkoutResponseDTO>? Workouts{get; set;}



    }
}
