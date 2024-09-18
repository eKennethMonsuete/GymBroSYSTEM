using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymBroINFRA.Entity
{
    [Table("measures")]
    public class Measures
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public long Id
        {
            get; set;
        }

        [Column("weight")]
        public double Weight
        {
            get; set;
        }

        [Column("right_biceps")]
        public double RightBiceps
        {
            get; set;
        }

        [Column("left_biceps")]
        public double LeftBiceps
        {
            get; set;
        }

        [Column("hips")]
        public double Hips
        {
            get; set;
        }

        [Column("right_quadriceps")]
        public double RightQuadriceps
        {
            get; set;
        }

        [Column("left_quadriceps")]
        public double LeftQuadriceps
        {
            get; set;
        }

        [Column("right_calf")]
        public double RightCalf
        {
            get; set;
        }

        [Column("left_calf")]
        public double LeftCalf
        {
            get; set;
        }


        [Required]
        [ForeignKey("student_id")]
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
