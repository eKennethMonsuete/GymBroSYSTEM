﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBroINFRA.Entity
{
    public class Workout
    {
        public long Id { get; set; }
        public string WorkoutName { get; set; }

        public string Exercise { get; set; }
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

        

        public long StudentId { get; set; }
        public virtual Student Student{  get; set; }
        
          
        
    }
}
