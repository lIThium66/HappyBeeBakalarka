using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VersionOneWA.Shared.Migrations
{
    /// <inheritdoc />
    public partial class addedStatusProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Status",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Status",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MyProperty",
                table: "Status",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Status",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Status_UserId",
                table: "Status",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Status_AspNetUsers_UserId",
                table: "Status",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Status_AspNetUsers_UserId",
                table: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Status_UserId",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Status");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Status",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
