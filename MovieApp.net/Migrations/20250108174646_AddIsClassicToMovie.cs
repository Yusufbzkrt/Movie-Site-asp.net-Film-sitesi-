using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieApp.net.Migrations
{
    public partial class AddIsClassicToMovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsClassic",
                table: "Movies",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsClassic",
                table: "Movies");
        }
    }
}
