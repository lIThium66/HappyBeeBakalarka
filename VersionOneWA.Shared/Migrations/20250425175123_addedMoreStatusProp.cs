using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VersionOneWA.Shared.Migrations
{
    /// <inheritdoc />
    public partial class addedMoreStatusProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "doneTreatment",
                table: "Status",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "suppliedSugar",
                table: "Status",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "suppliedWater",
                table: "Status",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "doneTreatment",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "suppliedSugar",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "suppliedWater",
                table: "Status");
        }
    }
}
