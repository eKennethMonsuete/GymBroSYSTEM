using System.ComponentModel.DataAnnotations.Schema;

namespace GymBroINFRA.Entity;

   
    public class Student : User
    {



    public long? PersonalId
    {
        get; set;
    }
    public virtual Personal Personal
    {
        get; set;
    }

    public virtual ICollection<Measures> Measures
    {
        get; set;
    }

    //public ICollection<Workout> Workouts{ get; set;}






}

