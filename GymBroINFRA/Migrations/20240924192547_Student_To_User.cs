using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymBroINFRA.Migrations
{
    /// <inheritdoc />
    public partial class Student_To_User : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Personal_PersonalId",
                table: "User");

            migrationBuilder.AlterColumn<long>(
                name: "PersonalId",
                table: "User",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "StudentId",
                table: "User",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Student",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 24, 16, 25, 47, 494, DateTimeKind.Local).AddTicks(7461),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 9, 24, 16, 17, 33, 566, DateTimeKind.Local).AddTicks(7060));

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Student",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Personal",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 24, 16, 25, 47, 495, DateTimeKind.Local).AddTicks(8163),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 9, 24, 16, 17, 33, 567, DateTimeKind.Local).AddTicks(358));

            migrationBuilder.CreateIndex(
                name: "IX_User_StudentId",
                table: "User",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_UserId",
                table: "Student",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_User_UserId",
                table: "Student",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Personal_PersonalId",
                table: "User",
                column: "PersonalId",
                principalTable: "Personal",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Student_StudentId",
                table: "User",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_User_UserId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Personal_PersonalId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Student_StudentId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_StudentId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Student_UserId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Student");

            migrationBuilder.AlterColumn<long>(
                name: "PersonalId",
                table: "User",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Student",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 24, 16, 17, 33, 566, DateTimeKind.Local).AddTicks(7060),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 9, 24, 16, 25, 47, 494, DateTimeKind.Local).AddTicks(7461));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Personal",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 24, 16, 17, 33, 567, DateTimeKind.Local).AddTicks(358),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 9, 24, 16, 25, 47, 495, DateTimeKind.Local).AddTicks(8163));

            migrationBuilder.AddForeignKey(
                name: "FK_User_Personal_PersonalId",
                table: "User",
                column: "PersonalId",
                principalTable: "Personal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
