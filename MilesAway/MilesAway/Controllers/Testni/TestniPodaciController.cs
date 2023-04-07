using Microsoft.AspNetCore.Mvc;
using MilesAway.Data;
using MilesAway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilesAway.Controllers.Testni
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TestniPodaciController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public TestniPodaciController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        public ActionResult Count()
        {
            Dictionary<string, int> data = new Dictionary<string, int>();
            data.Add("Kupac", _dbContext.Kupac.Count());
            data.Add("Menadzer", _dbContext.Menadzer.Count());
            data.Add("Korisnik", _dbContext.Korisnik.Count());
            data.Add("Drzava", _dbContext.Drzava.Count());
            data.Add("Grad", _dbContext.Grad.Count());
            data.Add("Aerodrom", _dbContext.Aerodrom.Count());
            data.Add("Avion", _dbContext.Avion.Count());
            data.Add("Aviokompanija", _dbContext.Aviokompanija.Count());
            data.Add("Pilot", _dbContext.Pilot.Count());
            data.Add("Let", _dbContext.Let.Count());
            data.Add("Presjedanje", _dbContext.Presjedanje.Count());
            data.Add("Tip Karte", _dbContext.TipKarte.Count());
            data.Add("Tip Putnika", _dbContext.TipPutnika.Count());
            data.Add("Vrsta popusta", _dbContext.VrstaPopust.Count());
            data.Add("Tip prtljage", _dbContext.TipPrtljage.Count());
            data.Add("Karta", _dbContext.Karta.Count());
            data.Add("Obavijest kategorija", _dbContext.ObavijestKategorije.Count());
            data.Add("Obavijest", _dbContext.Obavijest.Count());
            data.Add("Izvjestaj", _dbContext.Izvjestaj.Count());
            data.Add("Kartica", _dbContext.Kartica.Count());
            data.Add("Kupljena karta", _dbContext.KupljenaKarta.Count());
            data.Add("Aerodrom-Let", _dbContext.AerodromLet.Count());
            data.Add("Avion-Let", _dbContext.AvionLet.Count());
            data.Add("Pilot-Let", _dbContext.PilotLet.Count());
            data.Add("VrstaPutanjeKarta", _dbContext.VrstaPutanjeKarte.Count());

            return Ok(data);
        }

        [HttpPost]
        public ActionResult Generisi()
        {
            var drzave = new List<Drzava>();
            var grad = new List<Grad>();
            var aerodrom = new List<Aerodrom>();
            var aviokompanija = new List<Aviokompanija>();
            var avion = new List<Avion>();
            var pilot = new List<Pilot>();
            var let = new List<Let>();
            var presjedanje = new List<Presjedanje>();
            var tipkarte = new List<TipKarte>();
            var tipPutnika = new List<TipPutnika>();
            var vrstapopusta = new List<VrstaPopusta>();
            var tipprtljage = new List<TipPrtljage>();
            var karta = new List<Karta>();
            var obavijestkategorija = new List<ObavijestKategorije>();
            var izvjestaj = new List<Izvjestaj>();
            var kartica = new List<Kartica>();
            var kupljenakarta = new List<KupljenaKarta>();
            var obavijest = new List<Obavijest>();
            var kupac = new List<Kupac>();
            var menadzer = new List<Menadzer>();
            var aerodromlet = new List<AerodromLet>();
            var avionlet = new List<AvionLet>();
            var pilotlet = new List<PilotLet>();
            var putanja = new List<VrstaPutanjeKarte>();


            drzave.Add(new Drzava { Naziv = "BiH" });               //0 
            drzave.Add(new Drzava { Naziv = "HR" });                //1
            drzave.Add(new Drzava { Naziv = "Njemacka" });          //2
            drzave.Add(new Drzava { Naziv = "Austrija" });          //3
            drzave.Add(new Drzava { Naziv = "SAD" });               //4
            drzave.Add(new Drzava { Naziv = "Srbija" });            //5
            drzave.Add(new Drzava { Naziv = "Francuska" });         //6
            drzave.Add(new Drzava { Naziv = "Turska" });            //7
            drzave.Add(new Drzava { Naziv = "Italija" });           //8


            grad.Add(new Grad { Naziv = "Sarajevo", Drzava = drzave[0] });             //0
            grad.Add(new Grad { Naziv = "Mostar", Drzava = drzave[0] });               //1
            grad.Add(new Grad { Naziv = "Tuzla", Drzava = drzave[0] });                //2
                                                                                       
            grad.Add(new Grad { Naziv = "Split", Drzava = drzave[1] });                //3
            grad.Add(new Grad { Naziv = "Zagreb", Drzava = drzave[1] });               //4
            grad.Add(new Grad { Naziv = "Dubrovnik", Drzava = drzave[1] });            //5
                                                                                       
            grad.Add(new Grad { Naziv = "Berlin", Drzava = drzave[2] });               //6
            grad.Add(new Grad { Naziv = "Frankfurt", Drzava = drzave[2] });            //7

            grad.Add(new Grad { Naziv = "Gratz", Drzava = drzave[3] });                //8
            grad.Add(new Grad { Naziv = "Vienna", Drzava = drzave[3] });               //9

            grad.Add(new Grad { Naziv = "Boston", Drzava = drzave[4] });                //10
            grad.Add(new Grad { Naziv = "New York", Drzava = drzave[4] });              //11

            grad.Add(new Grad { Naziv = "Beograd", Drzava = drzave[5] });          //12
            grad.Add(new Grad { Naziv = "Niš", Drzava = drzave[5] });           //13

            grad.Add(new Grad { Naziv = "Pariz", Drzava = drzave[6] });          //14
            grad.Add(new Grad { Naziv = "Marseille", Drzava = drzave[6] });         //15

            grad.Add(new Grad { Naziv = "Istanbul", Drzava = drzave[7] });          //16
            grad.Add(new Grad { Naziv = "Ankara", Drzava = drzave[7] });            //17

            grad.Add(new Grad { Naziv = "Milan", Drzava = drzave[8] });          //18
            grad.Add(new Grad { Naziv = "Rim", Drzava = drzave[8] });            //19


            aerodrom.Add(new Aerodrom { Naziv = "Medjunarodni aerodrom Sarajevo", Grad = grad[0] });
            aerodrom.Add(new Aerodrom { Naziv = "Medjunarodni aerodrom Mostar", Grad = grad[1] });
            aerodrom.Add(new Aerodrom { Naziv = "Medjunarodni aerodrom Tuzla", Grad = grad[2] });

            aerodrom.Add(new Aerodrom { Naziv = "Zracna luka Split", Grad = grad[3] });
            aerodrom.Add(new Aerodrom { Naziv = "Zracna luka Franja Tudjman", Grad = grad[4] });
            aerodrom.Add(new Aerodrom { Naziv = "Zracna luka Dubrovnik", Grad = grad[5] });

            aerodrom.Add(new Aerodrom { Naziv = "Brandenburg Berlin", Grad = grad[6] });
            aerodrom.Add(new Aerodrom { Naziv = "Frankfurt airport", Grad = grad[7] });

            aerodrom.Add(new Aerodrom { Naziv = "Zracna luka Vienna", Grad = grad[9] });
            aerodrom.Add(new Aerodrom { Naziv = "Zracna luka Gratz", Grad = grad[8] });

            aerodrom.Add(new Aerodrom { Naziv = "Medjunarodna zracna luka Boston", Grad = grad[10] });
            aerodrom.Add(new Aerodrom { Naziv = "JFK aerodrom", Grad = grad[11] });

            aerodrom.Add(new Aerodrom { Naziv = "Aerodrom Nikola Tesla Beograd", Grad = grad[12] });
            aerodrom.Add(new Aerodrom { Naziv = "Aerodrom Konstantin Veliki Niš", Grad = grad[13] });


            aerodrom.Add(new Aerodrom { Naziv = "Charles de Gaulle aerodrom", Grad = grad[14] });
            aerodrom.Add(new Aerodrom { Naziv = "Aerodrom Marseille Provence", Grad = grad[15] });

            aerodrom.Add(new Aerodrom { Naziv = "Aerodrom Istanbul", Grad = grad[16] });
            aerodrom.Add(new Aerodrom { Naziv = "Aerodrom Esenboga", Grad = grad[17] }); 

            aerodrom.Add(new Aerodrom { Naziv = "Milano Malpensa", Grad = grad[18] });
            aerodrom.Add(new Aerodrom { Naziv = "Leonardo da Vinci aerdorom", Grad = grad[19] });


            aviokompanija.Add(new Aviokompanija { Naziv = "WizzAir" });
            aviokompanija.Add(new Aviokompanija { Naziv = "RyanAir" });
            aviokompanija.Add(new Aviokompanija { Naziv = "Lufthans" });
            aviokompanija.Add(new Aviokompanija { Naziv = "Turkish airlines" });
            aviokompanija.Add(new Aviokompanija { Naziv = "jetBlue" });
            aviokompanija.Add(new Aviokompanija { Naziv = "Emirates" });



            avion.Add(new Avion { BrojRegistracije = "Airbus A320-200", Aviokompanija = aviokompanija[0],BrojMaxSjedista =186, BrojSjedistaBusiness=26,BrojSjedistaPrveKlase=10,DatumZadnjegServisa=DateTime.Now});
            avion.Add(new Avion { BrojRegistracije = "Airbus A320neo", Aviokompanija = aviokompanija[0], BrojMaxSjedista = 326, BrojSjedistaBusiness = 50, BrojSjedistaPrveKlase = 20, DatumZadnjegServisa = DateTime.Now});

            avion.Add(new Avion { BrojRegistracije = "Airbus A380", Aviokompanija = aviokompanija[2], BrojMaxSjedista = 186, BrojSjedistaBusiness = 26, BrojSjedistaPrveKlase = 10, DatumZadnjegServisa = DateTime.Now });
          
            avion.Add(new Avion { BrojRegistracije = "Boing 727-100", Aviokompanija = aviokompanija[1], BrojMaxSjedista = 326, BrojSjedistaBusiness = 50, BrojSjedistaPrveKlase = 20, DatumZadnjegServisa = DateTime.Now });

            avion.Add(new Avion { BrojRegistracije = "Airbus A330-200", Aviokompanija = aviokompanija[3], BrojMaxSjedista = 220, BrojSjedistaBusiness = 20, BrojSjedistaPrveKlase = 10, DatumZadnjegServisa = DateTime.Now });
            avion.Add(new Avion { BrojRegistracije = "Boing 737 Max 8", Aviokompanija = aviokompanija[3], BrojMaxSjedista = 151, BrojSjedistaBusiness = 10, BrojSjedistaPrveKlase = 6, DatumZadnjegServisa = DateTime.Now });

            avion.Add(new Avion { BrojRegistracije = "Airbus A320", Aviokompanija = aviokompanija[4], BrojMaxSjedista = 186, BrojSjedistaBusiness = 26, BrojSjedistaPrveKlase = 10, DatumZadnjegServisa = DateTime.Now });
            
            avion.Add(new Avion { BrojRegistracije = "Boing 777", Aviokompanija = aviokompanija[5], BrojMaxSjedista = 326, BrojSjedistaBusiness = 50, BrojSjedistaPrveKlase = 20, DatumZadnjegServisa = DateTime.Now });



            var rnd = new Random();

            for (int i = 0; i < 5; i++)
            {
                pilot.Add(new Pilot
                { Ime = "Pilot"+ i, Prezime = "Pilot"+ i, Spol = 'M',
                    JMBG = $"{i:d}150051", DatumRodjenja = new DateTime(rnd.Next(1980, 1995), rnd.Next(1, 13), rnd.Next(1, 29)),
                    DatumZaposlenja = DateTime.Now, BrojDozvole = $"BH{i:d}J",
                    Kontakt =$"061-{rnd.Next(0,9)}{rnd.Next(0, 9)}{rnd.Next(0, 9)}-{rnd.Next(0,9)}{rnd.Next(0, 9)}{rnd.Next(0, 9)}" ,
                    Adresa = "Ulica br." + i
                });
            }

            for (int i = 0; i < 10; i++)
            {
        /*0*/      let.Add(new Let { SifraLeta = "BH21MO0"+i, Polaziste = grad[0], Destinacija = grad[16], DatumVrijemePolaska = DateTime.Now.AddDays(i), VrijemeDolaska = DateTime.Now.AddDays(i).AddHours(3), JednosmijernaCijena = 150, PovratnaCijena = (150 + 1) * 2 });
        /*1*/      let.Add(new Let { SifraLeta = "BH21MO1"+i, Polaziste = grad[0], Destinacija = grad[9], DatumVrijemePolaska = DateTime.Now.AddDays(i), VrijemeDolaska = DateTime.Now.AddDays(i).AddHours(1), JednosmijernaCijena = 120, PovratnaCijena = (150) * 2 });
        /*2*/      let.Add(new Let { SifraLeta = "BH21MO2"+i, Polaziste = grad[0], Destinacija = grad[14], DatumVrijemePolaska = DateTime.Now.AddDays(i), VrijemeDolaska = DateTime.Now.AddDays(i).AddHours(3), JednosmijernaCijena = 130, PovratnaCijena = (130 + 1) * 2 });
        /*3*/      let.Add(new Let { SifraLeta = "BH21MO3"+i, Polaziste = grad[0], Destinacija = grad[6], DatumVrijemePolaska = DateTime.Now.AddDays(i), VrijemeDolaska = DateTime.Now.AddDays(i).AddHours(1.5), JednosmijernaCijena = 100, PovratnaCijena = (100 + 5) * 2 });
        /*4*/      let.Add(new Let { SifraLeta = "BH21MO4"+i, Polaziste = grad[0], Destinacija = grad[11], DatumVrijemePolaska = DateTime.Now.AddDays(i), VrijemeDolaska = DateTime.Now.AddDays(i).AddHours(15), JednosmijernaCijena = 1500, PovratnaCijena = (1500) * 2 });
        
        /*5*/      let.Add(new Let { SifraLeta = "BH21MO5"+i, Polaziste = grad[16], Destinacija = grad[0], DatumVrijemePolaska = DateTime.Now.AddDays(i), VrijemeDolaska = DateTime.Now.AddDays(i).AddHours(3),  JednosmijernaCijena = 150, PovratnaCijena = (150 + 1) * 2 });
        /*5*/      let.Add(new Let { SifraLeta = "BH21MO6"+i, Polaziste = grad[9], Destinacija = grad[0], DatumVrijemePolaska = DateTime.Now.AddDays(i), VrijemeDolaska = DateTime.Now.AddDays(i).AddHours(1), JednosmijernaCijena = 120, PovratnaCijena = (150) * 2 });
        /*7*/      let.Add(new Let { SifraLeta = "BH21MO7"+i, Polaziste = grad[14], Destinacija = grad[0], DatumVrijemePolaska = DateTime.Now.AddDays(i), VrijemeDolaska = DateTime.Now.AddDays(i).AddHours(3),  JednosmijernaCijena = 130, PovratnaCijena = (130 + 1) * 2 });
        /*8*/      let.Add(new Let { SifraLeta = "BH21MO8"+i, Polaziste = grad[6], Destinacija = grad[0], DatumVrijemePolaska = DateTime.Now.AddDays(i), VrijemeDolaska = DateTime.Now.AddDays(i).AddHours(1.5),JednosmijernaCijena = 100, PovratnaCijena = (100 + 5) * 2 });
        /*9*/      let.Add(new Let { SifraLeta = "BH21MO9"+i, Polaziste = grad[11], Destinacija = grad[0], DatumVrijemePolaska = DateTime.Now.AddDays(i), VrijemeDolaska = DateTime.Now.AddDays(i).AddHours(15), JednosmijernaCijena = 1500, PovratnaCijena = (1500) * 2 });
            }
           


            presjedanje.Add(new Presjedanje { MjestoPresjedanja = grad[7], Let = let[2], VrijemeDolaska = let[2].DatumVrijemePolaska.AddHours(1), VrijemePolaska = let[2].DatumVrijemePolaska.AddHours(3) });
            presjedanje.Add(new Presjedanje { MjestoPresjedanja = grad[14], Let = let[4], VrijemeDolaska = let[4].DatumVrijemePolaska.AddHours(1), VrijemePolaska = let[4].DatumVrijemePolaska.AddHours(3) });


            presjedanje.Add(new Presjedanje { MjestoPresjedanja = grad[7], Let = let[7], VrijemeDolaska = let[7].DatumVrijemePolaska.AddHours(1), VrijemePolaska = let[7].DatumVrijemePolaska.AddHours(3) });
            presjedanje.Add(new Presjedanje { MjestoPresjedanja = grad[14], Let = let[9], VrijemeDolaska = let[9].DatumVrijemePolaska.AddHours(1), VrijemePolaska = let[9].DatumVrijemePolaska.AddHours(3) });




            tipkarte.Add(new TipKarte { Naziv = "Business",Cijena=150 });
            tipkarte.Add(new TipKarte { Naziv = "Economy",Cijena=0 });
            tipkarte.Add(new TipKarte { Naziv = "Prva klasa",Cijena=200 });


            tipPutnika.Add(new TipPutnika { Naziv = "Djeca(0-2)", Cijena = 0 });
            tipPutnika.Add(new TipPutnika { Naziv = "Djeca(3-17)", Cijena = 0 });
            tipPutnika.Add(new TipPutnika { Naziv = "Odrasli(18-64)", Cijena = 100 });
            tipPutnika.Add(new TipPutnika { Naziv = "Penzinoeri(65+)", Cijena = 50 });


            vrstapopusta.Add(new VrstaPopusta { Naziv="10%", Aktivan=true,Popust=(0.10f)});
            vrstapopusta.Add(new VrstaPopusta { Naziv = "20%", Aktivan = true, Popust = 0.20f });
            vrstapopusta.Add(new VrstaPopusta { Naziv = "50%", Aktivan = false, Popust = 0.50f });


            tipprtljage.Add(new TipPrtljage { Naziv = "Rucna - 8KG", CijenaDodatak = 0 });
            tipprtljage.Add(new TipPrtljage { Naziv = "Kofer - 20KG", CijenaDodatak = 25 });


            putanja.Add(new VrstaPutanjeKarte { Naziv = "Jednosmjerna" });
            putanja.Add(new VrstaPutanjeKarte { Naziv = "Povratna" });

            for (int i = 0; i < 10; i++)
            {
                karta.Add(new Karta { Cijena = let[0].JednosmijernaCijena, Sjediste = "C"+i, Let = let[0], TipKarte = tipkarte[0], Aktivna = true, Putanja = putanja[0] });
                karta.Add(new Karta { Cijena = let[1].JednosmijernaCijena, Sjediste = "A"+i, Let = let[1], TipKarte = tipkarte[1], Aktivna = true, Putanja = putanja[0] });
                karta.Add(new Karta { Cijena = let[2].JednosmijernaCijena, Sjediste = "B"+i, Let = let[2], TipKarte = tipkarte[2], Aktivna = true, Putanja = putanja[0] });
                karta.Add(new Karta { Cijena = let[3].JednosmijernaCijena, Sjediste = "C"+i, Let = let[3], TipKarte = tipkarte[0], Aktivna = false, Putanja = putanja[0] });
                karta.Add(new Karta { Cijena = let[4].JednosmijernaCijena, Sjediste = "C"+i, Let = let[4], TipKarte = tipkarte[1], Aktivna = true, Putanja = putanja[0] });
                karta.Add(new Karta { Cijena = let[5].JednosmijernaCijena, Sjediste = "C1"+i, Let = let[5], TipKarte = tipkarte[0], Aktivna = true, Putanja = putanja[0] });
                karta.Add(new Karta { Cijena = let[6].JednosmijernaCijena, Sjediste = "A1"+i, Let = let[6], TipKarte = tipkarte[1], Aktivna = true, Putanja = putanja[0] });
                karta.Add(new Karta { Cijena = let[7].JednosmijernaCijena, Sjediste = "B11"+i, Let = let[7], TipKarte = tipkarte[2], Aktivna = true, Putanja = putanja[0] });
                karta.Add(new Karta { Cijena = let[8].JednosmijernaCijena, Sjediste = "C12"+i, Let = let[8], TipKarte = tipkarte[0], Aktivna = false, Putanja = putanja[0] });
                karta.Add(new Karta { Cijena = let[9].JednosmijernaCijena, Sjediste = "C10"+i, Let = let[9], TipKarte = tipkarte[1], Aktivna = true, Putanja = putanja[0] });

                karta.Add(new Karta { Cijena = let[0].PovratnaCijena, Sjediste = "C" + i, Let = let[0], TipKarte = tipkarte[0], Aktivna = true, Putanja = putanja[1] });
                karta.Add(new Karta { Cijena = let[1].PovratnaCijena, Sjediste = "A" + i, Let = let[1], TipKarte = tipkarte[1], Aktivna = true, Putanja = putanja[1] });
                karta.Add(new Karta { Cijena = let[2].PovratnaCijena, Sjediste = "B" + i, Let = let[2], TipKarte = tipkarte[2], Aktivna = true, Putanja = putanja[1] });
                karta.Add(new Karta { Cijena = let[3].PovratnaCijena, Sjediste = "C" + i, Let = let[3], TipKarte = tipkarte[0], Aktivna = false, Putanja = putanja[1] });
                karta.Add(new Karta { Cijena = let[4].PovratnaCijena, Sjediste = "C" + i, Let = let[4], TipKarte = tipkarte[1], Aktivna = true, Putanja = putanja[1] });
                karta.Add(new Karta { Cijena = let[5].PovratnaCijena, Sjediste = "C1" + i, Let = let[5], TipKarte = tipkarte[0], Aktivna = true, Putanja = putanja[1] });
                karta.Add(new Karta { Cijena = let[6].PovratnaCijena, Sjediste = "A1" + i, Let = let[6], TipKarte = tipkarte[1], Aktivna = true, Putanja = putanja[1] });
                karta.Add(new Karta { Cijena = let[7].PovratnaCijena, Sjediste = "B11" + i, Let = let[7], TipKarte = tipkarte[2], Aktivna = true, Putanja = putanja[1] });
                karta.Add(new Karta { Cijena = let[8].PovratnaCijena, Sjediste = "C12" + i, Let = let[8], TipKarte = tipkarte[0], Aktivna = false, Putanja = putanja[1] });
                karta.Add(new Karta { Cijena = let[9].PovratnaCijena, Sjediste = "C10" + i, Let = let[9], TipKarte = tipkarte[1], Aktivna = true, Putanja = putanja[1] });

            }


            obavijestkategorija.Add(new ObavijestKategorije { Naziv = "Vijesti"});
            obavijestkategorija.Add(new ObavijestKategorije { Naziv = "Novosti"});
            obavijestkategorija.Add(new ObavijestKategorije { Naziv = "Izmjene"});


            for (int i = 0; i < 10; i++)
            {
                kupac.Add(new Kupac { Ime = "Ime"+ i,Prezime="Prezime"+ i,slika_korisnika="",korisnickoIme="ime"+ i,lozinka="test"});
            }


            menadzer.Add(new Menadzer
            {
                Ime = "Majla",
                Prezime = "Arap",
                slika_korisnika = "",
                DatumZaposlenja = DateTime.Now.AddYears(10),
                Adresa = "Brace Laksica 5",
                BrojTelefona = $"061-{rnd.Next(0, 9)}{rnd.Next(0, 9)}{rnd.Next(0, 9)}-{rnd.Next(0, 9)}{rnd.Next(0, 9)}{rnd.Next(0, 9)}",
                korisnickoIme = "test",
                lozinka = "test123",
                isAdmin = true,               
            });

            menadzer.Add(new Menadzer
            {
                Ime = "Adla",
                Prezime = "Kajtaz",
                slika_korisnika = "",
                DatumZaposlenja = DateTime.Now.AddYears(10),
                Adresa = "Brace Laksica 6",
                BrojTelefona = $"061-{rnd.Next(0, 9)}{rnd.Next(0, 9)}{rnd.Next(0, 9)}-{rnd.Next(0, 9)}{rnd.Next(0, 9)}{rnd.Next(0, 9)}",
                korisnickoIme = "menadzer",
                lozinka = "test123",
                isAdmin = true
            });

            obavijest.Add(new Obavijest { Naslov = "Vremenske nepogode",PodNaslov="NEvrijeme u Sarajevu", Opis="Zbog nevremena u Sarajevu let Berlin - Sarajevo odgadja se za dva sata",Slika="",DatumKreiranja=DateTime.Now, ObavijestKategorija=obavijestkategorija[1],Menadzer=menadzer[0]});


            kartica.Add(new Kartica { BrojKartice = "4582 1549 1325 2154", DatumIsteka = DateTime.Now.AddYears(4), VerifikacijskiKod = 212, Kupac=kupac[0] });
            kartica.Add(new Kartica { BrojKartice = "1564 2546 1564 1478", DatumIsteka = DateTime.Now.AddYears(4), VerifikacijskiKod = 254, Kupac = kupac[2] });


            kupljenakarta.Add(new KupljenaKarta { DatumKupovine = DateTime.Now, Kupac = kupac[0], Karta = karta[0], PostojiPopust = false, IsAktivna = true, TipPutnika = tipPutnika[1], TipPrtljage = tipprtljage[0], Povratna = false,DatumPolaska=karta[0].Let.DatumVrijemePolaska});
            kupljenakarta.Add(new KupljenaKarta { DatumKupovine = DateTime.Now.AddDays(-5), Kupac = kupac[5], Karta = karta[3], PostojiPopust = true, IsAktivna = false,Popust=vrstapopusta[0],TipPutnika=tipPutnika[2],TipPrtljage=tipprtljage[1],Povratna=true, DatumPolaska = karta[3].Let.DatumVrijemePolaska, DatumPovratka = karta[3].Let.DatumVrijemePolaska.AddDays(5) });

            aerodromlet.Add(new AerodromLet { Aerodrom1 = aerodrom[0],Aerodrom2=aerodrom[16], Let=let[0] });
            aerodromlet.Add(new AerodromLet { Aerodrom1 = aerodrom[0],Aerodrom2=aerodrom[8], Let=let[1] });
            aerodromlet.Add(new AerodromLet { Aerodrom1 = aerodrom[0],Aerodrom2=aerodrom[14], Let=let[2] });
            aerodromlet.Add(new AerodromLet { Aerodrom1 = aerodrom[0], Aerodrom2 = aerodrom[6], Let = let[3] });
            aerodromlet.Add(new AerodromLet { Aerodrom1 = aerodrom[0], Aerodrom2 = aerodrom[11], Let = let[4] });
            aerodromlet.Add(new AerodromLet { Aerodrom1 = aerodrom[16], Aerodrom2 = aerodrom[0], Let = let[5] }); 
            aerodromlet.Add(new AerodromLet { Aerodrom1 = aerodrom[8], Aerodrom2 = aerodrom[0], Let = let[6] });
            aerodromlet.Add(new AerodromLet { Aerodrom1 = aerodrom[14], Aerodrom2 = aerodrom[0], Let = let[7] });
            aerodromlet.Add(new AerodromLet { Aerodrom1 = aerodrom[6], Aerodrom2 = aerodrom[0], Let = let[8] });
            aerodromlet.Add(new AerodromLet { Aerodrom1 = aerodrom[11], Aerodrom2 = aerodrom[0], Let = let[9] });

            avionlet.Add(new AvionLet { Avion = avion[0], Let = let[0] });
            avionlet.Add(new AvionLet { Avion = avion[1], Let = let[1] });
            avionlet.Add(new AvionLet { Avion = avion[2], Let = let[2] });
            avionlet.Add(new AvionLet { Avion = avion[3], Let = let[3] });
            avionlet.Add(new AvionLet { Avion = avion[4], Let = let[4] });
            avionlet.Add(new AvionLet { Avion = avion[5], Let = let[5] });
            avionlet.Add(new AvionLet { Avion = avion[6], Let = let[6] });
            avionlet.Add(new AvionLet { Avion = avion[7], Let = let[7] });
            avionlet.Add(new AvionLet { Avion = avion[0], Let = let[8] });
            avionlet.Add(new AvionLet { Avion = avion[1], Let = let[9] });
         

            pilotlet.Add(new PilotLet {Pilot=pilot[0], Let = let[0] });
            pilotlet.Add(new PilotLet {Pilot=pilot[1], Let = let[1] });
            pilotlet.Add(new PilotLet {Pilot=pilot[2], Let = let[2] });
            pilotlet.Add(new PilotLet {Pilot=pilot[3], Let = let[3] });
            pilotlet.Add(new PilotLet {Pilot = pilot[4],Let = let[4] });
            pilotlet.Add(new PilotLet {Pilot = pilot[1],Let = let[5] });
            pilotlet.Add(new PilotLet {Pilot = pilot[2],Let = let[6] });
            pilotlet.Add(new PilotLet {Pilot = pilot[3], Let = let[7] });
            pilotlet.Add(new PilotLet { Pilot = pilot[0], Let = let[8] });
            pilotlet.Add(new PilotLet { Pilot = pilot[3], Let = let[9] });



            _dbContext.AddRange(aerodrom);
            _dbContext.AddRange(avion);
            _dbContext.AddRange(grad);
            _dbContext.AddRange(drzave);
            _dbContext.AddRange(aviokompanija);
            _dbContext.AddRange(aerodrom);
            _dbContext.AddRange(avion);
            _dbContext.AddRange(tipkarte);
            _dbContext.AddRange(tipPutnika);
            _dbContext.AddRange(tipprtljage);
            _dbContext.AddRange(vrstapopusta);
            _dbContext.AddRange(kartica);
            _dbContext.AddRange(kupac);
            _dbContext.AddRange(kupljenakarta);
            _dbContext.AddRange(avionlet);
            _dbContext.AddRange(aerodromlet);
            _dbContext.AddRange(pilotlet);
            _dbContext.AddRange(pilot);
            _dbContext.AddRange(obavijest);
            _dbContext.AddRange(aerodromlet);
            _dbContext.AddRange(let);
            _dbContext.AddRange(menadzer);
            _dbContext.AddRange(izvjestaj);
            _dbContext.AddRange(putanja);
            _dbContext.AddRange(presjedanje);
            _dbContext.AddRange(karta);
            _dbContext.AddRange(obavijestkategorija);
            _dbContext.SaveChanges();

            return Count();
        }
    }
}

