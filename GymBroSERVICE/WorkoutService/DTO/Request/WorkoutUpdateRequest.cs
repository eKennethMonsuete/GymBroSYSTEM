using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBroSERVICE.WorkoutService.DTO.Request
{
    public class WorkoutUpdateRequest
    {
        public string WorkoutName
        {
            get; set;
        }
        public string Exercise
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

        public long StudentId
        {
            get; set;
        }
    }
}
