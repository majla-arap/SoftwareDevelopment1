using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MilesAway.Migrations
{
    public partial class slika : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Slika_",
                table: "Obavijest",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slika_",
                table: "Obavijest");
        }
    }
}
