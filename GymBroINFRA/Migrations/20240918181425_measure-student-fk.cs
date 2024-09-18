using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymBroINFRA.Migrations
{
    /// <inheritdoc />
    public partial class measurestudentfk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_measures_students_user_id",
                table: "measures");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "measures",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_measures_user_id",
                table: "measures",
                newName: "IX_measures_StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_measures_students_StudentId",
                table: "measures",
                column: "StudentId",
                principalTable: "students",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_measures_students_StudentId",
                table: "measures");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "measures",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "IX_measures_StudentId",
                table: "measures",
                newName: "IX_measures_user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_measures_students_user_id",
                table: "measures",
                column: "user_id",
                principalTable: "students",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
