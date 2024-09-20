using System.ComponentModel.DataAnnotations.Schema;

namespace GymBroINFRA.Entity;

   [Table("students")]
    public class Student : User
    {

   
   [ForeignKey("teacher_id")]
    public  long TeacherId
    {
        get; set;
    }
    public virtual Teacher Teacher
    {
        get; set;
    }

    public virtual ICollection<Measures>? Measures
    {
        get; set;
    }

    //public ICollection<Workout> Workouts{ get; set;}
       
    
    



}

