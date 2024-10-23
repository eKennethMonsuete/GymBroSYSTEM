using System.ComponentModel.DataAnnotations.Schema;

namespace GymBroINFRA.Entity;

   
    public class Student 
    {
    public long Id
    {
        get; set;
    }

    public string Name
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

    public DateTime CreatedAt
    {
        get; set;
    }

    public bool IsActived
    {
        get; set;
    }



    public long? PersonalId
    {
        get; set;
    }
    public virtual Personal? Personal
    {
        get; set;
    }

    public long UserId
    {
        get; set;
    }

    public virtual User User
    {
        get; set;
    }

    public virtual ICollection<Measures> Measures
    {
        get; set;
    }
    public virtual ICollection<Workout> Workout
    {
        get; set;
    }

    //public ICollection<Workout> Workouts{ get; set;}






}

