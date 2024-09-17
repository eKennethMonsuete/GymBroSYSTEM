using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymBroINFRA.Migrations
{
    /// <inheritdoc />
    public partial class ralacionamento_Measures_user : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "MeasureId",
                table: "user",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "User",
                table: "measures",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "measures",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_measures_UserId",
                table: "measures",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_measures_user_UserId",
                table: "measures",
                column: "UserId",
                principalTable: "user",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_measures_user_UserId",
                table: "measures");

            migrationBuilder.DropIndex(
                name: "IX_measures_UserId",
                table: "measures");

            migrationBuilder.DropColumn(
                name: "MeasureId",
                table: "user");

            migrationBuilder.DropColumn(
                name: "User",
                table: "measures");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "measures");
        }
    }
}
