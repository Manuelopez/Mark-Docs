using Microsoft.EntityFrameworkCore.Migrations;

namespace LeagueServer.Migrations
{
    public partial class LeagueDbV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Champion",
                table: "Posts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Posts",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Champion",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Posts");
        }
    }
}
