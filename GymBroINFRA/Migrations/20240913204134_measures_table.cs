using Microsoft.EntityFrameworkCore.Migrations;

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymBroINFRA.Migrations
{
    /// <inheritdoc />
    public partial class measures_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "left_calf",
                table: "measures",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "left_quadriceps",
                table: "measures",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "right_calf",
                table: "measures",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "right_quadriceps",
                table: "measures",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "left_calf",
                table: "measures");

            migrationBuilder.DropColumn(
                name: "left_quadriceps",
                table: "measures");

            migrationBuilder.DropColumn(
                name: "right_calf",
                table: "measures");

            migrationBuilder.DropColumn(
                name: "right_quadriceps",
                table: "measures");
        }
    }
}
