using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymBroINFRA.Migrations
{
    /// <inheritdoc />
    public partial class New_Db_Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_measures_user_UserId",
                table: "measures");

            migrationBuilder.DropColumn(
                name: "MeasureId",
                table: "user");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "measures",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "IX_measures_UserId",
                table: "measures",
                newName: "IX_measures_user_id");

            migrationBuilder.AddColumn<int>(
                name: "user_role",
                table: "user",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "teacher",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teacher", x => x.id);
                    table.ForeignKey(
                        name: "FK_teacher_user_id",
                        column: x => x.id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    TeacherId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.id);
                    table.ForeignKey(
                        name: "FK_students_teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "teacher",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_students_user_id",
                        column: x => x.id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_students_TeacherId",
                table: "students",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_measures_students_user_id",
                table: "measures",
                column: "user_id",
                principalTable: "students",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_measures_students_user_id",
                table: "measures");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "teacher");

            migrationBuilder.DropColumn(
                name: "user_role",
                table: "user");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "measures",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_measures_user_id",
                table: "measures",
                newName: "IX_measures_UserId");

            migrationBuilder.AddColumn<long>(
                name: "MeasureId",
                table: "user",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_measures_user_UserId",
                table: "measures",
                column: "UserId",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
