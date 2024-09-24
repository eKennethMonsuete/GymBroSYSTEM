using GymBroINFRA.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymBroINFRA.config
{
    public class PersonalConfiguration : IEntityTypeConfiguration<Personal>
    {
        public void Configure(EntityTypeBuilder<Personal> builder)
        {
            builder.ToTable(nameof(Personal));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired(true);

            builder.Property(x => x.LastName);
            builder.Property(x => x.Phone);
            builder.Property(x => x.IsActived);
            builder.Property(x => x.UserId);

            builder.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasDefaultValue(DateTime.Now)
                .IsRequired(true);

            builder.HasMany(p => p.Students).
                WithOne(e => e.Personal)
                .HasForeignKey(e => e.PersonalId);

            builder.HasOne(p => p.User).WithOne().HasForeignKey<Personal>(p => p.UserId);


            
        }
    }
}
