﻿// <auto-generated />
using GymBroINFRA.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GymBroINFRA.Migrations
{
    [DbContext(typeof(MySQLContext))]
    partial class MySQLContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("GymBroINFRA.Entity.Measures", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("Id"));

                    b.Property<double>("Hips")
                        .HasColumnType("double")
                        .HasColumnName("hips");

                    b.Property<double>("LeftBiceps")
                        .HasColumnType("double")
                        .HasColumnName("left_biceps");

                    b.Property<double>("LeftCalf")
                        .HasColumnType("double")
                        .HasColumnName("left_calf");

                    b.Property<double>("LeftQuadriceps")
                        .HasColumnType("double")
                        .HasColumnName("left_quadriceps");

                    b.Property<double>("RightBiceps")
                        .HasColumnType("double")
                        .HasColumnName("right_biceps");

                    b.Property<double>("RightCalf")
                        .HasColumnType("double")
                        .HasColumnName("right_calf");

                    b.Property<double>("RightQuadriceps")
                        .HasColumnType("double")
                        .HasColumnName("right_quadriceps");

                    b.Property<long>("StudentId")
                        .HasColumnType("bigint");

                    b.Property<double>("Weight")
                        .HasColumnType("double")
                        .HasColumnName("weight");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("measures", (string)null);
                });

            modelBuilder.Entity("GymBroINFRA.Entity.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("last_name");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("password");

                    b.Property<int>("userRole")
                        .HasColumnType("int")
                        .HasColumnName("user_role");

                    b.HasKey("Id");

                    b.ToTable("users", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("GymBroINFRA.Entity.Student", b =>
                {
                    b.HasBaseType("GymBroINFRA.Entity.User");

                    b.Property<long>("TeacherId")
                        .HasColumnType("bigint")
                        .HasColumnName("teacher_id");

                    b.HasIndex("TeacherId");

                    b.ToTable("students", (string)null);
                });

            modelBuilder.Entity("GymBroINFRA.Entity.Teacher", b =>
                {
                    b.HasBaseType("GymBroINFRA.Entity.User");

                    b.ToTable("teachers", (string)null);
                });

            modelBuilder.Entity("GymBroINFRA.Entity.Measures", b =>
                {
                    b.HasOne("GymBroINFRA.Entity.Student", "Student")
                        .WithMany("Measures")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("GymBroINFRA.Entity.Student", b =>
                {
                    b.HasOne("GymBroINFRA.Entity.User", null)
                        .WithOne()
                        .HasForeignKey("GymBroINFRA.Entity.Student", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GymBroINFRA.Entity.Teacher", "Teacher")
                        .WithMany("Students")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("GymBroINFRA.Entity.Teacher", b =>
                {
                    b.HasOne("GymBroINFRA.Entity.User", null)
                        .WithOne()
                        .HasForeignKey("GymBroINFRA.Entity.Teacher", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GymBroINFRA.Entity.Student", b =>
                {
                    b.Navigation("Measures");
                });

            modelBuilder.Entity("GymBroINFRA.Entity.Teacher", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
