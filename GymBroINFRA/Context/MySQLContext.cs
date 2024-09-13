using GymBroDOMAIN.Entity;
using Microsoft.EntityFrameworkCore;

namespace GymBroINFRA.Context
{
    public class MySQLContext : DbContext
    {

        public MySQLContext()
        {
        }
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        





    }
}
