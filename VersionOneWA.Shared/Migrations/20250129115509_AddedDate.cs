using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VersionOneWA.Shared.Migrations
{
    /// <inheritdoc />
    public partial class AddedDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "JobDate",
                table: "Jobs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "numberOfBees",
                table: "Beehives",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "beehiveWeight",
                table: "Beehives",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "QueensAge",
                table: "Beehives",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobDate",
                table: "Jobs");

            migrationBuilder.AlterColumn<int>(
                name: "numberOfBees",
                table: "Beehives",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "beehiveWeight",
                table: "Beehives",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "QueensAge",
                table: "Beehives",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
