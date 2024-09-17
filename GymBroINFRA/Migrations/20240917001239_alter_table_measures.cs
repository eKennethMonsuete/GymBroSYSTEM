using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymBroINFRA.Migrations
{
    /// <inheritdoc />
    public partial class alter_table_measures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_measures_user_UserId",
                table: "measures");

            migrationBuilder.DropColumn(
                name: "User",
                table: "measures");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "measures",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_measures_user_UserId",
                table: "measures",
                column: "UserId",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_measures_user_UserId",
                table: "measures");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "measures",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "User",
                table: "measures",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_measures_user_UserId",
                table: "measures",
                column: "UserId",
                principalTable: "user",
                principalColumn: "id");
        }
    }
}
