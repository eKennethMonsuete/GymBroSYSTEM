using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymBroINFRA.Entity
{
    
    public class Measures
    {
        
        public long Id
        {
            get; set;
        }

        
        public double Weight
        {
            get; set;
        }

        
        public double RightBiceps
        {
            get; set;
        }

       
        public double LeftBiceps
        {
            get; set;
        }

        
        public double Hips
        {
            get; set;
        }

        
        public double RightQuadriceps
        {
            get; set;
        }

        
        public double LeftQuadriceps
        {
            get; set;
        }

        
        public double RightCalf
        {
            get; set;
        }

        
        public double LeftCalf
        {
            get; set;
        }

        public DateTime CreatedAt
        {
            get; set;
        }

        public string PreviousDate
        {
        
        get; set; 
        }




        public long StudentId
        {
            get; set;
        }


        public virtual Student Student
        {
            get; set;
        }














    }
}
