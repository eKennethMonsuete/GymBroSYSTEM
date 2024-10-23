using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymBroINFRA.Migrations
{
    /// <inheritdoc />
    public partial class workout_table_updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Workout1",
                table: "Workout");

            migrationBuilder.DropColumn(
                name: "Workout2",
                table: "Workout");

            migrationBuilder.DropColumn(
                name: "Workout3",
                table: "Workout");

            migrationBuilder.RenameColumn(
                name: "Workout4",
                table: "Workout",
                newName: "Description");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Workout",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 23, 16, 42, 14, 349, DateTimeKind.Local).AddTicks(8088),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 10, 23, 15, 8, 49, 14, DateTimeKind.Local).AddTicks(5936));

            migrationBuilder.AddColumn<string>(
                name: "Exercise",
                table: "Workout",
                type: "TEXT",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Student",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 23, 16, 42, 14, 345, DateTimeKind.Local).AddTicks(9096),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 10, 23, 15, 8, 49, 11, DateTimeKind.Local).AddTicks(6491));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Personal",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 23, 16, 42, 14, 347, DateTimeKind.Local).AddTicks(2036),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 10, 23, 15, 8, 49, 12, DateTimeKind.Local).AddTicks(8470));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Measures",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 23, 16, 42, 14, 348, DateTimeKind.Local).AddTicks(3020),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 10, 23, 15, 8, 49, 13, DateTimeKind.Local).AddTicks(8746));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Exercise",
                table: "Workout");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Workout",
                newName: "Workout4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Workout",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 23, 15, 8, 49, 14, DateTimeKind.Local).AddTicks(5936),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 10, 23, 16, 42, 14, 349, DateTimeKind.Local).AddTicks(8088));

            migrationBuilder.AddColumn<string>(
                name: "Workout1",
                table: "Workout",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Workout2",
                table: "Workout",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Workout3",
                table: "Workout",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Student",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 23, 15, 8, 49, 11, DateTimeKind.Local).AddTicks(6491),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 10, 23, 16, 42, 14, 345, DateTimeKind.Local).AddTicks(9096));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Personal",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 23, 15, 8, 49, 12, DateTimeKind.Local).AddTicks(8470),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 10, 23, 16, 42, 14, 347, DateTimeKind.Local).AddTicks(2036));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Measures",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 23, 15, 8, 49, 13, DateTimeKind.Local).AddTicks(8746),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 10, 23, 16, 42, 14, 348, DateTimeKind.Local).AddTicks(3020));
        }
    }
}
