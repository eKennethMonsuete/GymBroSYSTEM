using GymBroINFRA.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace GymBroINFRA.config
{
    public class MeasuresConfiguration : IEntityTypeConfiguration<Measures>
    {
        public void Configure(EntityTypeBuilder<Measures> builder)
        {
            builder.ToTable("measures");

            builder.HasKey(m => m.Id);

            builder.HasOne(m => m.Student) 
                 .WithMany(s => s.Measures) 
                 .HasForeignKey(m => m.StudentId) 
                 .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
