using System.ComponentModel.DataAnnotations.Schema;

namespace GymBroDOMAIN.Entity
{
    [Table("measures")]
    public class Measures1
    {
        [Column("Id")]
        public long Id { get; set; }

        [Column("weight")]
        public double Weight { get; set; }

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




    }
}
