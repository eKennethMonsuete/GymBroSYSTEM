using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymBroINFRA.Migrations
{
    /// <inheritdoc />
    public partial class tabelas_sem_herança : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Student",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 24, 15, 39, 20, 128, DateTimeKind.Local).AddTicks(7438),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 9, 24, 15, 8, 30, 347, DateTimeKind.Local).AddTicks(9487));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Personal",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 24, 15, 39, 20, 128, DateTimeKind.Local).AddTicks(9875),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 9, 24, 15, 8, 30, 348, DateTimeKind.Local).AddTicks(2678));

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActived = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Student",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 24, 15, 8, 30, 347, DateTimeKind.Local).AddTicks(9487),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 9, 24, 15, 39, 20, 128, DateTimeKind.Local).AddTicks(7438));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Personal",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 24, 15, 8, 30, 348, DateTimeKind.Local).AddTicks(2678),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 9, 24, 15, 39, 20, 128, DateTimeKind.Local).AddTicks(9875));
        }
    }
}
