using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VersionOneWA.Shared.Migrations
{
    /// <inheritdoc />
    public partial class editStatProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MyProperty",
                table: "Status",
                newName: "Report");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Report",
                table: "Status",
                newName: "MyProperty");
        }
    }
}
