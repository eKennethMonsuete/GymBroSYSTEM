using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymBroINFRA.Migrations
{
    /// <inheritdoc />
    public partial class RelationPersonalStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Student",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 20, 16, 5, 38, 911, DateTimeKind.Local).AddTicks(6779),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 9, 20, 15, 51, 2, 615, DateTimeKind.Local).AddTicks(393));

            migrationBuilder.AddColumn<long>(
                name: "PersonalId",
                table: "Student",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Personal",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 20, 16, 5, 38, 912, DateTimeKind.Local).AddTicks(17),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 9, 20, 15, 51, 2, 615, DateTimeKind.Local).AddTicks(2388));

            migrationBuilder.CreateIndex(
                name: "IX_Student_PersonalId",
                table: "Student",
                column: "PersonalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Personal_PersonalId",
                table: "Student",
                column: "PersonalId",
                principalTable: "Personal",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Personal_PersonalId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_PersonalId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "PersonalId",
                table: "Student");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Student",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 20, 15, 51, 2, 615, DateTimeKind.Local).AddTicks(393),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 9, 20, 16, 5, 38, 911, DateTimeKind.Local).AddTicks(6779));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Personal",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 20, 15, 51, 2, 615, DateTimeKind.Local).AddTicks(2388),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 9, 20, 16, 5, 38, 912, DateTimeKind.Local).AddTicks(17));
        }
    }
}
