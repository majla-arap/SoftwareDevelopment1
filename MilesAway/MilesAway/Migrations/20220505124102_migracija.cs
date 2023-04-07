using Microsoft.EntityFrameworkCore.Migrations;

namespace MilesAway.Migrations
{
    public partial class migracija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imeVlasnika",
                table: "Kartica",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imeVlasnika",
                table: "Kartica");
        }
    }
}
