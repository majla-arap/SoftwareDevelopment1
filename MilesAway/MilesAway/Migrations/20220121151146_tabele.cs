using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MilesAway.Migrations
{
    public partial class tabele : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aviokompanija",
                columns: table => new
                {
                    AviokompanijaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aviokompanija", x => x.AviokompanijaID);
                });

            migrationBuilder.CreateTable(
                name: "Drzava",
                columns: table => new
                {
                    DrzavaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzava", x => x.DrzavaID);
                });

            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    KorisnikID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    korisnickoIme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lozinka = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    slika_korisnika = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.KorisnikID);
                });

            migrationBuilder.CreateTable(
                name: "ObavijestKategorije",
                columns: table => new
                {
                    ObavijestKategorijeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObavijestKategorije", x => x.ObavijestKategorijeID);
                });

            migrationBuilder.CreateTable(
                name: "Pilot",
                columns: table => new
                {
                    PilotID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Spol = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    JMBG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumZaposlenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BrojDozvole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kontakt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pilot", x => x.PilotID);
                });

            migrationBuilder.CreateTable(
                name: "TipKarte",
                columns: table => new
                {
                    TipID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cijena = table.Column<float>(type: "real", nullable: false),
                    IsAktivan = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipKarte", x => x.TipID);
                });

            migrationBuilder.CreateTable(
                name: "TipPrtljage",
                columns: table => new
                {
                    TipID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CijenaDodatak = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipPrtljage", x => x.TipID);
                });

            migrationBuilder.CreateTable(
                name: "TipPutnika",
                columns: table => new
                {
                    TipID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cijena = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipPutnika", x => x.TipID);
                });

            migrationBuilder.CreateTable(
                name: "VrstaPopust",
                columns: table => new
                {
                    PopustID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Popust = table.Column<float>(type: "real", nullable: false),
                    Aktivan = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VrstaPopust", x => x.PopustID);
                });

            migrationBuilder.CreateTable(
                name: "Avion",
                columns: table => new
                {
                    AvionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojRegistracije = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojMaxSjedista = table.Column<int>(type: "int", nullable: false),
                    DatumZadnjegServisa = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BrojSjedistaPrveKlase = table.Column<int>(type: "int", nullable: false),
                    BrojSjedistaBusiness = table.Column<int>(type: "int", nullable: false),
                    AviokompanijaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avion", x => x.AvionID);
                    table.ForeignKey(
                        name: "FK_Avion_Aviokompanija_AviokompanijaID",
                        column: x => x.AviokompanijaID,
                        principalTable: "Aviokompanija",
                        principalColumn: "AviokompanijaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Grad",
                columns: table => new
                {
                    GradID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrzavaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grad", x => x.GradID);
                    table.ForeignKey(
                        name: "FK_Grad_Drzava_DrzavaID",
                        column: x => x.DrzavaID,
                        principalTable: "Drzava",
                        principalColumn: "DrzavaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AutentifikacijaToken",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vrijednost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KorisnickiNalogId = table.Column<int>(type: "int", nullable: false),
                    vrijemeEvidentiranja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ipAdresa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutentifikacijaToken", x => x.id);
                    table.ForeignKey(
                        name: "FK_AutentifikacijaToken_Korisnik_KorisnickiNalogId",
                        column: x => x.KorisnickiNalogId,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kupac",
                columns: table => new
                {
                    KorisnikID = table.Column<int>(type: "int", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kupac", x => x.KorisnikID);
                    table.ForeignKey(
                        name: "FK_Kupac_Korisnik_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Menadzer",
                columns: table => new
                {
                    KorisnikID = table.Column<int>(type: "int", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumZaposlenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojTelefona = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menadzer", x => x.KorisnikID);
                    table.ForeignKey(
                        name: "FK_Menadzer_Korisnik_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Aerodrom",
                columns: table => new
                {
                    AerodromID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GradID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aerodrom", x => x.AerodromID);
                    table.ForeignKey(
                        name: "FK_Aerodrom_Grad_GradID",
                        column: x => x.GradID,
                        principalTable: "Grad",
                        principalColumn: "GradID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Let",
                columns: table => new
                {
                    LetID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SifraLeta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PolazisteGradID = table.Column<int>(type: "int", nullable: true),
                    DestinacijaGradID = table.Column<int>(type: "int", nullable: true),
                    DatumVrijemePolaska = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VrijemeDolaska = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VrijemeTrajanja = table.Column<TimeSpan>(type: "time", nullable: false),
                    JednosmijernaCijena = table.Column<float>(type: "real", nullable: false),
                    PovratnaCijena = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Let", x => x.LetID);
                    table.ForeignKey(
                        name: "FK_Let_Grad_DestinacijaGradID",
                        column: x => x.DestinacijaGradID,
                        principalTable: "Grad",
                        principalColumn: "GradID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Let_Grad_PolazisteGradID",
                        column: x => x.PolazisteGradID,
                        principalTable: "Grad",
                        principalColumn: "GradID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Kartica",
                columns: table => new
                {
                    KarticaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojKartice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumIsteka = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VerifikacijskiKod = table.Column<int>(type: "int", nullable: false),
                    KupacID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kartica", x => x.KarticaID);
                    table.ForeignKey(
                        name: "FK_Kartica_Kupac_KupacID",
                        column: x => x.KupacID,
                        principalTable: "Kupac",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Izvjestaj",
                columns: table => new
                {
                    IzvjestajID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sadrzaj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MenadzerID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Izvjestaj", x => x.IzvjestajID);
                    table.ForeignKey(
                        name: "FK_Izvjestaj_Menadzer_MenadzerID",
                        column: x => x.MenadzerID,
                        principalTable: "Menadzer",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Obavijest",
                columns: table => new
                {
                    ObavijestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naslov = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PodNaslov = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slika = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumKreiranja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ObavijestKategorijeID = table.Column<int>(type: "int", nullable: true),
                    MenadzerID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obavijest", x => x.ObavijestID);
                    table.ForeignKey(
                        name: "FK_Obavijest_Menadzer_MenadzerID",
                        column: x => x.MenadzerID,
                        principalTable: "Menadzer",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Obavijest_ObavijestKategorije_ObavijestKategorijeID",
                        column: x => x.ObavijestKategorijeID,
                        principalTable: "ObavijestKategorije",
                        principalColumn: "ObavijestKategorijeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AerodromLet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LetID = table.Column<int>(type: "int", nullable: true),
                    AerodromID = table.Column<int>(type: "int", nullable: true),
                    AerodromID_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AerodromLet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AerodromLet_Aerodrom_AerodromID",
                        column: x => x.AerodromID,
                        principalTable: "Aerodrom",
                        principalColumn: "AerodromID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AerodromLet_Aerodrom_AerodromID_ID",
                        column: x => x.AerodromID_ID,
                        principalTable: "Aerodrom",
                        principalColumn: "AerodromID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AerodromLet_Let_LetID",
                        column: x => x.LetID,
                        principalTable: "Let",
                        principalColumn: "LetID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AvionLet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AvionID = table.Column<int>(type: "int", nullable: true),
                    LetID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvionLet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvionLet_Avion_AvionID",
                        column: x => x.AvionID,
                        principalTable: "Avion",
                        principalColumn: "AvionID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AvionLet_Let_LetID",
                        column: x => x.LetID,
                        principalTable: "Let",
                        principalColumn: "LetID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Karta",
                columns: table => new
                {
                    KartaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cijena = table.Column<float>(type: "real", nullable: false),
                    Aktivna = table.Column<bool>(type: "bit", nullable: false),
                    Sjediste = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipKarteID = table.Column<int>(type: "int", nullable: true),
                    LetID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Karta", x => x.KartaID);
                    table.ForeignKey(
                        name: "FK_Karta_Let_LetID",
                        column: x => x.LetID,
                        principalTable: "Let",
                        principalColumn: "LetID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Karta_TipKarte_TipKarteID",
                        column: x => x.TipKarteID,
                        principalTable: "TipKarte",
                        principalColumn: "TipID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PilotLet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PilotID = table.Column<int>(type: "int", nullable: true),
                    LetID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PilotLet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PilotLet_Let_LetID",
                        column: x => x.LetID,
                        principalTable: "Let",
                        principalColumn: "LetID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PilotLet_Pilot_PilotID",
                        column: x => x.PilotID,
                        principalTable: "Pilot",
                        principalColumn: "PilotID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Presjedanje",
                columns: table => new
                {
                    PresjedanjeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VrijemeDolaska = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VrijemePolaska = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GradID = table.Column<int>(type: "int", nullable: true),
                    LetID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presjedanje", x => x.PresjedanjeID);
                    table.ForeignKey(
                        name: "FK_Presjedanje_Grad_GradID",
                        column: x => x.GradID,
                        principalTable: "Grad",
                        principalColumn: "GradID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Presjedanje_Let_LetID",
                        column: x => x.LetID,
                        principalTable: "Let",
                        principalColumn: "LetID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KupljenaKarta",
                columns: table => new
                {
                    KupljenaKartaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumKupovine = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsAktivna = table.Column<bool>(type: "bit", nullable: false),
                    PostojiPopust = table.Column<bool>(type: "bit", nullable: false),
                    KartaID = table.Column<int>(type: "int", nullable: true),
                    KupacID = table.Column<int>(type: "int", nullable: true),
                    PopustID = table.Column<int>(type: "int", nullable: true),
                    TipPutnikaID = table.Column<int>(type: "int", nullable: true),
                    TipPrtljageID = table.Column<int>(type: "int", nullable: true),
                    Povratna = table.Column<bool>(type: "bit", nullable: false),
                    DatumPolaska = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumPovratka = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KupljenaKarta", x => x.KupljenaKartaID);
                    table.ForeignKey(
                        name: "FK_KupljenaKarta_Karta_KartaID",
                        column: x => x.KartaID,
                        principalTable: "Karta",
                        principalColumn: "KartaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KupljenaKarta_Kupac_KupacID",
                        column: x => x.KupacID,
                        principalTable: "Kupac",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KupljenaKarta_TipPrtljage_TipPrtljageID",
                        column: x => x.TipPrtljageID,
                        principalTable: "TipPrtljage",
                        principalColumn: "TipID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KupljenaKarta_TipPutnika_TipPutnikaID",
                        column: x => x.TipPutnikaID,
                        principalTable: "TipPutnika",
                        principalColumn: "TipID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KupljenaKarta_VrstaPopust_PopustID",
                        column: x => x.PopustID,
                        principalTable: "VrstaPopust",
                        principalColumn: "PopustID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aerodrom_GradID",
                table: "Aerodrom",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_AerodromLet_AerodromID",
                table: "AerodromLet",
                column: "AerodromID");

            migrationBuilder.CreateIndex(
                name: "IX_AerodromLet_AerodromID_ID",
                table: "AerodromLet",
                column: "AerodromID_ID");

            migrationBuilder.CreateIndex(
                name: "IX_AerodromLet_LetID",
                table: "AerodromLet",
                column: "LetID");

            migrationBuilder.CreateIndex(
                name: "IX_AutentifikacijaToken_KorisnickiNalogId",
                table: "AutentifikacijaToken",
                column: "KorisnickiNalogId");

            migrationBuilder.CreateIndex(
                name: "IX_Avion_AviokompanijaID",
                table: "Avion",
                column: "AviokompanijaID");

            migrationBuilder.CreateIndex(
                name: "IX_AvionLet_AvionID",
                table: "AvionLet",
                column: "AvionID");

            migrationBuilder.CreateIndex(
                name: "IX_AvionLet_LetID",
                table: "AvionLet",
                column: "LetID");

            migrationBuilder.CreateIndex(
                name: "IX_Grad_DrzavaID",
                table: "Grad",
                column: "DrzavaID");

            migrationBuilder.CreateIndex(
                name: "IX_Izvjestaj_MenadzerID",
                table: "Izvjestaj",
                column: "MenadzerID");

            migrationBuilder.CreateIndex(
                name: "IX_Karta_LetID",
                table: "Karta",
                column: "LetID");

            migrationBuilder.CreateIndex(
                name: "IX_Karta_TipKarteID",
                table: "Karta",
                column: "TipKarteID");

            migrationBuilder.CreateIndex(
                name: "IX_Kartica_KupacID",
                table: "Kartica",
                column: "KupacID");

            migrationBuilder.CreateIndex(
                name: "IX_KupljenaKarta_KartaID",
                table: "KupljenaKarta",
                column: "KartaID");

            migrationBuilder.CreateIndex(
                name: "IX_KupljenaKarta_KupacID",
                table: "KupljenaKarta",
                column: "KupacID");

            migrationBuilder.CreateIndex(
                name: "IX_KupljenaKarta_PopustID",
                table: "KupljenaKarta",
                column: "PopustID");

            migrationBuilder.CreateIndex(
                name: "IX_KupljenaKarta_TipPrtljageID",
                table: "KupljenaKarta",
                column: "TipPrtljageID");

            migrationBuilder.CreateIndex(
                name: "IX_KupljenaKarta_TipPutnikaID",
                table: "KupljenaKarta",
                column: "TipPutnikaID");

            migrationBuilder.CreateIndex(
                name: "IX_Let_DestinacijaGradID",
                table: "Let",
                column: "DestinacijaGradID");

            migrationBuilder.CreateIndex(
                name: "IX_Let_PolazisteGradID",
                table: "Let",
                column: "PolazisteGradID");

            migrationBuilder.CreateIndex(
                name: "IX_Obavijest_MenadzerID",
                table: "Obavijest",
                column: "MenadzerID");

            migrationBuilder.CreateIndex(
                name: "IX_Obavijest_ObavijestKategorijeID",
                table: "Obavijest",
                column: "ObavijestKategorijeID");

            migrationBuilder.CreateIndex(
                name: "IX_PilotLet_LetID",
                table: "PilotLet",
                column: "LetID");

            migrationBuilder.CreateIndex(
                name: "IX_PilotLet_PilotID",
                table: "PilotLet",
                column: "PilotID");

            migrationBuilder.CreateIndex(
                name: "IX_Presjedanje_GradID",
                table: "Presjedanje",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_Presjedanje_LetID",
                table: "Presjedanje",
                column: "LetID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AerodromLet");

            migrationBuilder.DropTable(
                name: "AutentifikacijaToken");

            migrationBuilder.DropTable(
                name: "AvionLet");

            migrationBuilder.DropTable(
                name: "Izvjestaj");

            migrationBuilder.DropTable(
                name: "Kartica");

            migrationBuilder.DropTable(
                name: "KupljenaKarta");

            migrationBuilder.DropTable(
                name: "Obavijest");

            migrationBuilder.DropTable(
                name: "PilotLet");

            migrationBuilder.DropTable(
                name: "Presjedanje");

            migrationBuilder.DropTable(
                name: "Aerodrom");

            migrationBuilder.DropTable(
                name: "Avion");

            migrationBuilder.DropTable(
                name: "Karta");

            migrationBuilder.DropTable(
                name: "Kupac");

            migrationBuilder.DropTable(
                name: "TipPrtljage");

            migrationBuilder.DropTable(
                name: "TipPutnika");

            migrationBuilder.DropTable(
                name: "VrstaPopust");

            migrationBuilder.DropTable(
                name: "Menadzer");

            migrationBuilder.DropTable(
                name: "ObavijestKategorije");

            migrationBuilder.DropTable(
                name: "Pilot");

            migrationBuilder.DropTable(
                name: "Aviokompanija");

            migrationBuilder.DropTable(
                name: "Let");

            migrationBuilder.DropTable(
                name: "TipKarte");

            migrationBuilder.DropTable(
                name: "Korisnik");

            migrationBuilder.DropTable(
                name: "Grad");

            migrationBuilder.DropTable(
                name: "Drzava");
        }
    }
}
