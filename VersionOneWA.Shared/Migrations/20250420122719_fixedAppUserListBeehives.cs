﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VersionOneWA.Shared.Migrations
{
    /// <inheritdoc />
    public partial class fixedAppUserListBeehives : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BeehiveBases_AspNetUsers_ApplicationUserId",
                table: "BeehiveBases");

            migrationBuilder.DropIndex(
                name: "IX_BeehiveBases_ApplicationUserId",
                table: "BeehiveBases");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "BeehiveBases");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "BeehiveBases",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BeehiveBases_ApplicationUserId",
                table: "BeehiveBases",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BeehiveBases_AspNetUsers_ApplicationUserId",
                table: "BeehiveBases",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
