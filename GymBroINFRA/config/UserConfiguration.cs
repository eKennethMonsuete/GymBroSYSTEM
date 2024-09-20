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
            builder.ToTable("users");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
               .HasColumnName("id")
               .IsRequired();

            builder.Property(u => u.Name)
                .HasColumnName("name")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(u => u.Email)
                .HasColumnName("email")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(u => u.Password)
                .HasColumnName("password")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(u => u.LastName)
                .HasColumnName("last_name")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(u => u.userRole)
                .HasColumnName("user_role")
                .IsRequired();

            
            builder.Property(u => u.CreationDate)
                .HasColumnName("creation_date")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");  

            
            builder.Property(u => u.IsActived)
                .HasColumnName("is_actived")
                .HasDefaultValue(true)
                .IsRequired();

            
            builder.Property(u => u.Ddd)
                .HasColumnName("ddd")
                .HasMaxLength(3);

            builder.Property(u => u.Whatsapp)
               .HasColumnName("whatsapp")
               .IsRequired();
               



        }
    }
}
