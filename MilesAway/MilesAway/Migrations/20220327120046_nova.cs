using Microsoft.EntityFrameworkCore.Migrations;

namespace MilesAway.Migrations
{
    public partial class nova : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PutanjaID",
                table: "Karta",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Karta_PutanjaID",
                table: "Karta",
                column: "PutanjaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Karta_VrstaPutanjeKarte_PutanjaID",
                table: "Karta",
                column: "PutanjaID",
                principalTable: "VrstaPutanjeKarte",
                principalColumn: "PutanjaID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Karta_VrstaPutanjeKarte_PutanjaID",
                table: "Karta");

            migrationBuilder.DropIndex(
                name: "IX_Karta_PutanjaID",
                table: "Karta");

            migrationBuilder.DropColumn(
                name: "PutanjaID",
                table: "Karta");
        }
    }
}
