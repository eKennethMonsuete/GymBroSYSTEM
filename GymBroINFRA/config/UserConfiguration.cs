using GymBroINFRA.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBroINFRA.config
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Email);
            builder.Property(x => x.Password);

            

            builder.HasOne(p => p.Personal).WithOne().HasForeignKey<User>(p => p.PersonalId);
            builder.HasOne(p => p.Student).WithOne().HasForeignKey<User>(p => p.StudentId);
        }
    }
}
