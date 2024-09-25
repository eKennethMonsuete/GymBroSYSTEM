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
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable(nameof(Student));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired(true);

            
            builder.Property(x => x.LastName);
            builder.Property(x => x.Phone);
            builder.Property(x => x.IsActived);

            builder.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasDefaultValue(DateTime.Now)
                .IsRequired(true);

                               

            builder.Property(s => s.PersonalId)
                .IsRequired(false);

            builder.HasOne(student => student.Personal)
                .WithMany(personal => personal.Students)
                .HasForeignKey(student => student.PersonalId);

            builder.HasMany(p => p.Measures).
               WithOne(e => e.Student)
               .HasForeignKey(e => e.StudentId);

            builder.HasOne(p => p.User).WithOne().HasForeignKey<Student>(p => p.UserId);

        }
    }
}
