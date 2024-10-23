﻿// <auto-generated />
using System;
using GymBroINFRA.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GymBroINFRA.Migrations
{
    [DbContext(typeof(MySQLContext))]
    [Migration("20241023021219_workout_added")]
    partial class workout_added
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2024, 10, 22, 23, 12, 18, 855, DateTimeKind.Local).AddTicks(869));

                    b.Property<double>("Hips")
                        .HasColumnType("double");

                    b.Property<double>("LeftBiceps")
                        .HasColumnType("double");

                    b.Property<double>("LeftCalf")
                        .HasColumnType("double");

                    b.Property<double>("LeftQuadriceps")
                        .HasColumnType("double");

                    b.Property<string>("PreviousDate")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("RightBiceps")
                        .HasColumnType("double");

                    b.Property<double>("RightCalf")
                        .HasColumnType("double");

                    b.Property<double>("RightQuadriceps")
                        .HasColumnType("double");

                    b.Property<long>("StudentId")
                        .HasColumnType("bigint");

                    b.Property<double>("Weight")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Measures", (string)null);
                });

            modelBuilder.Entity("GymBroINFRA.Entity.Personal", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2024, 10, 22, 23, 12, 18, 853, DateTimeKind.Local).AddTicks(2365));

                    b.Property<bool>("IsActived")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Personal", (string)null);
                });

            modelBuilder.Entity("GymBroINFRA.Entity.Student", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2024, 10, 22, 23, 12, 18, 851, DateTimeKind.Local).AddTicks(2002));

                    b.Property<bool>("IsActived")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<long?>("PersonalId")
                        .HasColumnType("bigint");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PersonalId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Student", (string)null);
                });

            modelBuilder.Entity("GymBroINFRA.Entity.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActived")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long?>("PersonalId")
                        .HasColumnType("bigint");

                    b.Property<long?>("StudentId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PersonalId")
                        .IsUnique();

                    b.HasIndex("StudentId")
                        .IsUnique();

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("GymBroINFRA.Entity.Workout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2024, 10, 22, 23, 12, 18, 856, DateTimeKind.Local).AddTicks(3460));

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("StudentId")
                        .HasColumnType("bigint");

                    b.Property<string>("Workout1")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Workout2")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Workout3")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Workout4")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("WorkoutName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Workout", (string)null);
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

            modelBuilder.Entity("GymBroINFRA.Entity.Personal", b =>
                {
                    b.HasOne("GymBroINFRA.Entity.User", "User")
                        .WithOne()
                        .HasForeignKey("GymBroINFRA.Entity.Personal", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("GymBroINFRA.Entity.Student", b =>
                {
                    b.HasOne("GymBroINFRA.Entity.Personal", "Personal")
                        .WithMany("Students")
                        .HasForeignKey("PersonalId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("GymBroINFRA.Entity.User", "User")
                        .WithOne()
                        .HasForeignKey("GymBroINFRA.Entity.Student", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Personal");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GymBroINFRA.Entity.User", b =>
                {
                    b.HasOne("GymBroINFRA.Entity.Personal", "Personal")
                        .WithOne()
                        .HasForeignKey("GymBroINFRA.Entity.User", "PersonalId");

                    b.HasOne("GymBroINFRA.Entity.Student", "Student")
                        .WithOne()
                        .HasForeignKey("GymBroINFRA.Entity.User", "StudentId");

                    b.Navigation("Personal");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("GymBroINFRA.Entity.Workout", b =>
                {
                    b.HasOne("GymBroINFRA.Entity.Student", "Student")
                        .WithMany("Workout")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("GymBroINFRA.Entity.Personal", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("GymBroINFRA.Entity.Student", b =>
                {
                    b.Navigation("Measures");

                    b.Navigation("Workout");
                });
#pragma warning restore 612, 618
        }
    }
}
