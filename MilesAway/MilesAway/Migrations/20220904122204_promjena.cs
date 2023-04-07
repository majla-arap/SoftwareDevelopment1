using Microsoft.EntityFrameworkCore.Migrations;

namespace MilesAway.Migrations
{
    public partial class promjena : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ime",
                table: "Menadzer");

            migrationBuilder.DropColumn(
                name: "Prezime",
                table: "Menadzer");

            migrationBuilder.DropColumn(
                name: "Ime",
                table: "Kupac");

            migrationBuilder.DropColumn(
                name: "Prezime",
                table: "Kupac");

            migrationBuilder.AddColumn<string>(
                name: "Ime",
                table: "Korisnik",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prezime",
                table: "Korisnik",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ime",
                table: "Korisnik");

            migrationBuilder.DropColumn(
                name: "Prezime",
                table: "Korisnik");

            migrationBuilder.AddColumn<string>(
                name: "Ime",
                table: "Menadzer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prezime",
                table: "Menadzer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ime",
                table: "Kupac",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prezime",
                table: "Kupac",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
