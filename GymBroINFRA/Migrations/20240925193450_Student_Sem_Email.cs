using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymBroINFRA.Migrations
{
    /// <inheritdoc />
    public partial class Student_Sem_Email : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Student");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Student",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 25, 16, 34, 50, 406, DateTimeKind.Local).AddTicks(6144),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 9, 25, 15, 26, 36, 56, DateTimeKind.Local).AddTicks(8733));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Personal",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 25, 16, 34, 50, 408, DateTimeKind.Local).AddTicks(1457),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 9, 25, 15, 26, 36, 61, DateTimeKind.Local).AddTicks(1225));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Measures",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 25, 16, 34, 50, 409, DateTimeKind.Local).AddTicks(5827),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 9, 25, 15, 26, 36, 64, DateTimeKind.Local).AddTicks(3735));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Student",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 25, 15, 26, 36, 56, DateTimeKind.Local).AddTicks(8733),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 9, 25, 16, 34, 50, 406, DateTimeKind.Local).AddTicks(6144));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Student",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Student",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Personal",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 25, 15, 26, 36, 61, DateTimeKind.Local).AddTicks(1225),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 9, 25, 16, 34, 50, 408, DateTimeKind.Local).AddTicks(1457));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Measures",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 25, 15, 26, 36, 64, DateTimeKind.Local).AddTicks(3735),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 9, 25, 16, 34, 50, 409, DateTimeKind.Local).AddTicks(5827));
        }
    }
}
