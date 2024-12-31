using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VersionOneWA.Shared.Migrations
{
    /// <inheritdoc />
    public partial class AddingBeehiveWeight : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "beehiveWeight",
                table: "Beehives",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "beehiveWeight",
                table: "Beehives");
        }
    }
}
