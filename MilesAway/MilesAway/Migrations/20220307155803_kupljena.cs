using Microsoft.EntityFrameworkCore.Migrations;

namespace MilesAway.Migrations
{
    public partial class kupljena : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Cijena",
                table: "KupljenaKarta",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cijena",
                table: "KupljenaKarta");
        }
    }
}
