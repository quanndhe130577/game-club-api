using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameClubAPI.Migrations
{
    public partial class altertableEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Events",
                newName: "Title");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Events",
                newName: "Name");
        }
    }
}
