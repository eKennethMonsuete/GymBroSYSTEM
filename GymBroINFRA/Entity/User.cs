using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBroINFRA.Entity
{

    [Table("user")]
    public class User
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public long Id { get; set;}  
                            
        [Column("name")]
        public string Name { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        
       // public long MeasureId {get; set; }

        public virtual ICollection<Measures>  Measures { get; set; }
        
        




    }
}
