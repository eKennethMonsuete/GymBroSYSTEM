using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymBroINFRA.Migrations
{
    /// <inheritdoc />
    public partial class updatedworkoutIdtolong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Workout",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 24, 0, 18, 25, 108, DateTimeKind.Local).AddTicks(1611),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 10, 23, 16, 42, 14, 349, DateTimeKind.Local).AddTicks(8088));

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Workout",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Student",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 24, 0, 18, 25, 103, DateTimeKind.Local).AddTicks(4462),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 10, 23, 16, 42, 14, 345, DateTimeKind.Local).AddTicks(9096));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Personal",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 24, 0, 18, 25, 105, DateTimeKind.Local).AddTicks(5106),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 10, 23, 16, 42, 14, 347, DateTimeKind.Local).AddTicks(2036));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Measures",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 24, 0, 18, 25, 107, DateTimeKind.Local).AddTicks(243),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 10, 23, 16, 42, 14, 348, DateTimeKind.Local).AddTicks(3020));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Workout",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 23, 16, 42, 14, 349, DateTimeKind.Local).AddTicks(8088),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 10, 24, 0, 18, 25, 108, DateTimeKind.Local).AddTicks(1611));

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Workout",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Student",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 23, 16, 42, 14, 345, DateTimeKind.Local).AddTicks(9096),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 10, 24, 0, 18, 25, 103, DateTimeKind.Local).AddTicks(4462));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Personal",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 23, 16, 42, 14, 347, DateTimeKind.Local).AddTicks(2036),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 10, 24, 0, 18, 25, 105, DateTimeKind.Local).AddTicks(5106));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Measures",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 23, 16, 42, 14, 348, DateTimeKind.Local).AddTicks(3020),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 10, 24, 0, 18, 25, 107, DateTimeKind.Local).AddTicks(243));
        }
    }
}
