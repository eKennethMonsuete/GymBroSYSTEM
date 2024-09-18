﻿using GymBroINFRA.Entity;
using Microsoft.EntityFrameworkCore;

namespace GymBroINFRA.Context
{
    public class MySQLContext : DbContext
    {

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options)
        {
        }

        public DbSet<Measures> Measures { get; set; }
        public DbSet<User> Users
        {
            get; set;
        }
        public DbSet<Student> Students
        {
            get; set;
        }
        public DbSet<Teacher> Teachers
        {
            get; set;
        }




    }
}
