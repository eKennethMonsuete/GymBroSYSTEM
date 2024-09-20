using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymBroINFRA.Migrations
{
    /// <inheritdoc />
    public partial class Relacao_Measure_Student : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Student",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 20, 16, 15, 32, 927, DateTimeKind.Local).AddTicks(2076),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 9, 20, 16, 11, 10, 509, DateTimeKind.Local).AddTicks(4131));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Personal",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 20, 16, 15, 32, 927, DateTimeKind.Local).AddTicks(6443),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 9, 20, 16, 11, 10, 509, DateTimeKind.Local).AddTicks(7430));

            migrationBuilder.AddColumn<long>(
                name: "StudentId",
                table: "Measures",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Measures_StudentId",
                table: "Measures",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Measures_Student_StudentId",
                table: "Measures",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Measures_Student_StudentId",
                table: "Measures");

            migrationBuilder.DropIndex(
                name: "IX_Measures_StudentId",
                table: "Measures");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Measures");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Student",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 20, 16, 11, 10, 509, DateTimeKind.Local).AddTicks(4131),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 9, 20, 16, 15, 32, 927, DateTimeKind.Local).AddTicks(2076));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Personal",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 20, 16, 11, 10, 509, DateTimeKind.Local).AddTicks(7430),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 9, 20, 16, 15, 32, 927, DateTimeKind.Local).AddTicks(6443));
        }
    }
}
