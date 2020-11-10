using Microsoft.EntityFrameworkCore.Migrations;

namespace LeagueServer.Migrations
{
    public partial class LeagueDbV5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SecondaryPage",
                table: "Runes",
                newName: "Secondary");

            migrationBuilder.RenameColumn(
                name: "PrimaryPage",
                table: "Runes",
                newName: "Primary");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Secondary",
                table: "Runes",
                newName: "SecondaryPage");

            migrationBuilder.RenameColumn(
                name: "Primary",
                table: "Runes",
                newName: "PrimaryPage");
        }
    }
}
