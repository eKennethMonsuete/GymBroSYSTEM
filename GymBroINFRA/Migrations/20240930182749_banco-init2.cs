using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymBroINFRA.Migrations
{
    /// <inheritdoc />
    public partial class bancoinit2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Student",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 30, 15, 27, 49, 392, DateTimeKind.Local).AddTicks(6187),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 9, 27, 10, 18, 2, 918, DateTimeKind.Local).AddTicks(384));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Personal",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 30, 15, 27, 49, 393, DateTimeKind.Local).AddTicks(6984),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 9, 27, 10, 18, 2, 919, DateTimeKind.Local).AddTicks(2077));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Measures",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 30, 15, 27, 49, 394, DateTimeKind.Local).AddTicks(6825),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 9, 27, 10, 18, 2, 920, DateTimeKind.Local).AddTicks(2542));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Student",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 27, 10, 18, 2, 918, DateTimeKind.Local).AddTicks(384),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 9, 30, 15, 27, 49, 392, DateTimeKind.Local).AddTicks(6187));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Personal",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 27, 10, 18, 2, 919, DateTimeKind.Local).AddTicks(2077),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 9, 30, 15, 27, 49, 393, DateTimeKind.Local).AddTicks(6984));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Measures",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 27, 10, 18, 2, 920, DateTimeKind.Local).AddTicks(2542),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 9, 30, 15, 27, 49, 394, DateTimeKind.Local).AddTicks(6825));
        }
    }
}
