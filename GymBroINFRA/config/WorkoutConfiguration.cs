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
    public class WorkoutConfiguration : IEntityTypeConfiguration<Workout>
    {
        public void Configure(EntityTypeBuilder<Workout> builder)
        {
            builder.ToTable(nameof(Workout));
            builder.HasKey(x => x.Id);
            builder.Property(x =>   x.WorkoutName).IsRequired();
            builder.Property(x => x.Workout1).IsRequired();
            builder.Property(x => x.Workout2);
            builder.Property(x => x.Workout3);
            builder.Property(x => x.Workout4);
            builder.Property(x => x.Note);

            builder.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasDefaultValue(DateTime.Now)
                .IsRequired(true);

            builder.Property(s => s.StudentId)
               .IsRequired(true);

            builder.HasOne(workout => workout.Student)
                .WithMany(student => student.Workout)
                .HasForeignKey(m => m.StudentId);



        }
    }
}
