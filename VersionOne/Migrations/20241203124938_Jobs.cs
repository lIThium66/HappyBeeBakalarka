using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VersionOne.Migrations
{
    /// <inheritdoc />
    public partial class Jobs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "Jobs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs");

            migrationBuilder.RenameTable(
                name: "Jobs",
                newName: "Tasks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "Id");
        }
    }
}
