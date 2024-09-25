using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymBroINFRA.Migrations
{
    /// <inheritdoc />
    public partial class Update_Student_PersonalId_Nullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Personal_PersonalId",
                table: "Student");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Student",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 25, 19, 11, 55, 868, DateTimeKind.Local).AddTicks(2183),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 9, 25, 16, 34, 50, 406, DateTimeKind.Local).AddTicks(6144));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Personal",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 25, 19, 11, 55, 869, DateTimeKind.Local).AddTicks(9551),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 9, 25, 16, 34, 50, 408, DateTimeKind.Local).AddTicks(1457));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Measures",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 25, 19, 11, 55, 871, DateTimeKind.Local).AddTicks(5596),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 9, 25, 16, 34, 50, 409, DateTimeKind.Local).AddTicks(5827));

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Personal_PersonalId",
                table: "Student",
                column: "PersonalId",
                principalTable: "Personal",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Personal_PersonalId",
                table: "Student");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Student",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 25, 16, 34, 50, 406, DateTimeKind.Local).AddTicks(6144),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 9, 25, 19, 11, 55, 868, DateTimeKind.Local).AddTicks(2183));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Personal",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 25, 16, 34, 50, 408, DateTimeKind.Local).AddTicks(1457),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 9, 25, 19, 11, 55, 869, DateTimeKind.Local).AddTicks(9551));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Measures",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 25, 16, 34, 50, 409, DateTimeKind.Local).AddTicks(5827),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 9, 25, 19, 11, 55, 871, DateTimeKind.Local).AddTicks(5596));

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Personal_PersonalId",
                table: "Student",
                column: "PersonalId",
                principalTable: "Personal",
                principalColumn: "Id");
        }
    }
}
