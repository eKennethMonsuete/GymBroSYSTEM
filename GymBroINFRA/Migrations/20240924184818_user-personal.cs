using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymBroINFRA.Migrations
{
    /// <inheritdoc />
    public partial class userpersonal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Student",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 24, 15, 48, 18, 634, DateTimeKind.Local).AddTicks(6941),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 9, 24, 15, 39, 20, 128, DateTimeKind.Local).AddTicks(7438));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Personal",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 24, 15, 48, 18, 634, DateTimeKind.Local).AddTicks(9528),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 9, 24, 15, 39, 20, 128, DateTimeKind.Local).AddTicks(9875));

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Personal",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Personal_UserId",
                table: "Personal",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Personal_User_UserId",
                table: "Personal",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personal_User_UserId",
                table: "Personal");

            migrationBuilder.DropIndex(
                name: "IX_Personal_UserId",
                table: "Personal");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Personal");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Student",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 24, 15, 39, 20, 128, DateTimeKind.Local).AddTicks(7438),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 9, 24, 15, 48, 18, 634, DateTimeKind.Local).AddTicks(6941));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Personal",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 24, 15, 39, 20, 128, DateTimeKind.Local).AddTicks(9875),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 9, 24, 15, 48, 18, 634, DateTimeKind.Local).AddTicks(9528));
        }
    }
}
