using Microsoft.EntityFrameworkCore.Migrations;

namespace MilesAway.Migrations
{
    public partial class karta1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DestinacijaGradID",
                table: "Karta",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PolazisteGradID",
                table: "Karta",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Karta_DestinacijaGradID",
                table: "Karta",
                column: "DestinacijaGradID");

            migrationBuilder.CreateIndex(
                name: "IX_Karta_PolazisteGradID",
                table: "Karta",
                column: "PolazisteGradID");

            migrationBuilder.AddForeignKey(
                name: "FK_Karta_Grad_DestinacijaGradID",
                table: "Karta",
                column: "DestinacijaGradID",
                principalTable: "Grad",
                principalColumn: "GradID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Karta_Grad_PolazisteGradID",
                table: "Karta",
                column: "PolazisteGradID",
                principalTable: "Grad",
                principalColumn: "GradID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Karta_Grad_DestinacijaGradID",
                table: "Karta");

            migrationBuilder.DropForeignKey(
                name: "FK_Karta_Grad_PolazisteGradID",
                table: "Karta");

            migrationBuilder.DropIndex(
                name: "IX_Karta_DestinacijaGradID",
                table: "Karta");

            migrationBuilder.DropIndex(
                name: "IX_Karta_PolazisteGradID",
                table: "Karta");

            migrationBuilder.DropColumn(
                name: "DestinacijaGradID",
                table: "Karta");

            migrationBuilder.DropColumn(
                name: "PolazisteGradID",
                table: "Karta");
        }
    }
}
