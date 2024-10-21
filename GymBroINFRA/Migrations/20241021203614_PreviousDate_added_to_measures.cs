using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymBroINFRA.Migrations
{
    /// <inheritdoc />
    public partial class PreviousDate_added_to_measures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Student",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 21, 17, 36, 13, 576, DateTimeKind.Local).AddTicks(7422),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 10, 17, 17, 15, 24, 729, DateTimeKind.Local).AddTicks(5573));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Personal",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 21, 17, 36, 13, 579, DateTimeKind.Local).AddTicks(4210),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 10, 17, 17, 15, 24, 731, DateTimeKind.Local).AddTicks(4533));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Measures",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 21, 17, 36, 13, 581, DateTimeKind.Local).AddTicks(7906),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 10, 17, 17, 15, 24, 733, DateTimeKind.Local).AddTicks(1040));

            migrationBuilder.AddColumn<string>(
                name: "PreviousDate",
                table: "Measures",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PreviousDate",
                table: "Measures");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Student",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 17, 17, 15, 24, 729, DateTimeKind.Local).AddTicks(5573),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 10, 21, 17, 36, 13, 576, DateTimeKind.Local).AddTicks(7422));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Personal",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 17, 17, 15, 24, 731, DateTimeKind.Local).AddTicks(4533),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 10, 21, 17, 36, 13, 579, DateTimeKind.Local).AddTicks(4210));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Measures",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 17, 17, 15, 24, 733, DateTimeKind.Local).AddTicks(1040),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 10, 21, 17, 36, 13, 581, DateTimeKind.Local).AddTicks(7906));
        }
    }
}
