using GymBroINFRA.config;
using GymBroINFRA.Entity;
using Microsoft.EntityFrameworkCore;

namespace GymBroINFRA.Context
{
    public class MySQLContext : DbContext
    {

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options)
        {
        }

        public DbSet<Measures> Measures { get; set; }
        
        public DbSet<Student> Students
        {
            get; set;
        }
        public DbSet<Personal> Personal
        {
            get; set;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new PersonalConfiguration());
            modelBuilder.ApplyConfiguration(new MeasuresConfiguration());

            base.OnModelCreating(modelBuilder);
        }




    }
}
