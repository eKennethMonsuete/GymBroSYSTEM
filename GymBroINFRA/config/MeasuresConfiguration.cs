using GymBroINFRA.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace GymBroINFRA.config
{
    public class MeasuresConfiguration : IEntityTypeConfiguration<Measures>
    {
        public void Configure(EntityTypeBuilder<Measures> builder)
        {
            builder.ToTable(nameof(Measures));

            builder.HasKey(m => m.Id);

            builder.Property(x => x.Weight);
            builder.Property(x => x.RightBiceps);
            builder.Property(x => x.LeftBiceps);
            builder.Property(x => x.Hips);
            builder.Property(x => x.RightQuadriceps);
            builder.Property(x => x.LeftQuadriceps);
            builder.Property(x => x.RightCalf);
            builder.Property(x => x.LeftCalf);
            builder.Property(x => x.PreviousDate);

            builder.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasDefaultValue(DateTime.Now)
                .IsRequired(true);

            builder.Property(s => s.StudentId)
               .IsRequired(true);

            builder.HasOne(measures => measures.Student )
                .WithMany(student => student.Measures)
                .HasForeignKey(m => m.StudentId);


            //builder.HasOne(m => m.Student) 
            //     .WithMany(s => s.Measures) 
            //     .HasForeignKey(m => m.StudentId) 
            //     .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
