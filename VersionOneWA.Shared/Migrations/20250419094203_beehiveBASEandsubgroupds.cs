using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VersionOneWA.Shared.Migrations
{
    /// <inheritdoc />
    public partial class beehiveBASEandsubgroupds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BeehiveBaseId",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BeehiveBaseId",
                table: "Beehives",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BeehiveBase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeehiveBase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BeehiveBase_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BeehiveMember",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BeehiveId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BeehiveBaseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeehiveMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BeehiveMember_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeehiveMember_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeehiveMember_BeehiveBase_BeehiveBaseId",
                        column: x => x.BeehiveBaseId,
                        principalTable: "BeehiveBase",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BeehiveMember_Beehives_BeehiveId",
                        column: x => x.BeehiveId,
                        principalTable: "Beehives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_BeehiveBaseId",
                table: "Jobs",
                column: "BeehiveBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Beehives_BeehiveBaseId",
                table: "Beehives",
                column: "BeehiveBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_BeehiveBase_UserId",
                table: "BeehiveBase",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BeehiveMember_BeehiveBaseId",
                table: "BeehiveMember",
                column: "BeehiveBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_BeehiveMember_BeehiveId",
                table: "BeehiveMember",
                column: "BeehiveId");

            migrationBuilder.CreateIndex(
                name: "IX_BeehiveMember_RoleId",
                table: "BeehiveMember",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_BeehiveMember_UserId",
                table: "BeehiveMember",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beehives_BeehiveBase_BeehiveBaseId",
                table: "Beehives",
                column: "BeehiveBaseId",
                principalTable: "BeehiveBase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_BeehiveBase_BeehiveBaseId",
                table: "Jobs",
                column: "BeehiveBaseId",
                principalTable: "BeehiveBase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beehives_BeehiveBase_BeehiveBaseId",
                table: "Beehives");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_BeehiveBase_BeehiveBaseId",
                table: "Jobs");

            migrationBuilder.DropTable(
                name: "BeehiveMember");

            migrationBuilder.DropTable(
                name: "BeehiveBase");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_BeehiveBaseId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Beehives_BeehiveBaseId",
                table: "Beehives");

            migrationBuilder.DropColumn(
                name: "BeehiveBaseId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "BeehiveBaseId",
                table: "Beehives");
        }
    }
}
