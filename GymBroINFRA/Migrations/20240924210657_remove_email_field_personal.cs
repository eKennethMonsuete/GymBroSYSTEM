using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymBroINFRA.Migrations
{
    /// <inheritdoc />
    public partial class remove_email_field_personal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Personal");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Personal");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Student",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 24, 18, 6, 56, 866, DateTimeKind.Local).AddTicks(8226),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 9, 24, 16, 25, 47, 494, DateTimeKind.Local).AddTicks(7461));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Personal",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 24, 18, 6, 56, 867, DateTimeKind.Local).AddTicks(5604),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 9, 24, 16, 25, 47, 495, DateTimeKind.Local).AddTicks(8163));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Student",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 24, 16, 25, 47, 494, DateTimeKind.Local).AddTicks(7461),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 9, 24, 18, 6, 56, 866, DateTimeKind.Local).AddTicks(8226));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Personal",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 24, 16, 25, 47, 495, DateTimeKind.Local).AddTicks(8163),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 9, 24, 18, 6, 56, 867, DateTimeKind.Local).AddTicks(5604));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Personal",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Personal",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
