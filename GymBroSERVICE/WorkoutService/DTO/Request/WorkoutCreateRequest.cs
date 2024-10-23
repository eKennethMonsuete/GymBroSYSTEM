using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBroSERVICE.WorkoutService.DTO.Request
{
    public class WorkoutCreateRequest
    {
        public int Id
        {
            get; set;
        }
        public string WorkoutName
        {
            get; set;
        }
        public string Workout
        {
            get; set;
        }
        

            public string Description
        {
            get; set;
        }

        public string Note
        {
            get; set;
        }
        public DateTime CreatedAt
        {
            get; set;
        }
        public long StudentId
        {
            get; set;
        }
    }
}
