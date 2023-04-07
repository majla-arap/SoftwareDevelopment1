using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MilesAway.Data;
using MilesAway.Helper;
using MilesAway.Models;

using MilesAway.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilesAway.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class KartaController : Controller
    {

        private readonly ApplicationDbContext _dbContext;

        public KartaController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }



        [HttpPost]
        public Karta Add([FromBody] KartaAddVM x)
        {
            var nova = new Karta
            {
               TipKarteID = x.TipKarteID,
               Sjediste=x.Sjediste,
               LetID=x.LetID,
               Cijena=x.Cijena,
               Aktivna=x.Aktivna,
            };

            _dbContext.Add(nova);
            _dbContext.SaveChanges();
            return nova;
        }

        [HttpGet]
        public ActionResult<RacunGetVM> GetByID(int id,int PrtljagaID,int TipPutnikaID)
        {

            Karta k = _dbContext.Karta
                .Include(x => x.Let)
                .Include(x=>x.Let.Polaziste)
                .Include(x=>x.Putanja)
                .Include(x=>x.Let.Destinacija)
                .Include(x=>x.TipKarte)
                .SingleOrDefault(x => x.KartaID == id);
            TipPrtljage p = _dbContext.TipPrtljage.SingleOrDefault(x => x.TipID == PrtljagaID);
            TipPutnika putnik = _dbContext.TipPutnika.SingleOrDefault(x => x.TipID == TipPutnikaID);
            if (k == null)
                return BadRequest("pogresan ID");
            var korisnik= HttpContext.GetLoginInfo()?.korisnickiNalog;
            var result = new RacunGetVM
            {
                DatumKupovine=DateTime.Now.ToString(),
                Ime=korisnik.korisnickoIme,
                Polaziste=k.Let.Polaziste.Naziv,
                Destinacija=k.Let.Destinacija.Naziv,
                DatumPolaska=k.Let.DatumVrijemePolaska.ToString(),
                DatumPovratka=k.Let.VrijemeDolaska.ToString(),
                TipKarte=k.TipKarte.Naziv,
                CijenaKarte=k.Cijena,
                CijenaPrtljage=p.CijenaDodatak,
                TipPrtljage=p.Naziv,
                TipPutnika=putnik.Naziv,
                DodatakTipPutnika=putnik.Cijena,
                UkupnaCijena=k.Cijena+p.CijenaDodatak+putnik.Cijena,
                PovratnaBool=k.Putanja.PutanjaID!=1
            };

            return result;
        }

        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
            List<KupljenaKarta> kk = _dbContext.KupljenaKarta.Where(x => x.KartaID == id).ToList();
            if (kk != null)
            {
                _dbContext.RemoveRange(kk);
                _dbContext.SaveChanges();
            }

            Karta karta = _dbContext.Karta.Find(id);

            if (karta == null)
                return BadRequest("Pogresan ID");

            _dbContext.Remove(karta);
            _dbContext.SaveChanges();
            return Ok(karta);

        }

        [HttpPost("{id}")]
        public ActionResult Update(int id, [FromBody] KartaAddVM x)
        {
            Karta karta = _dbContext.Karta.Find(id);


            if (karta == null)
                return BadRequest("Pogresan ID");

            karta.TipKarteID = x.TipKarteID;
            karta.Sjediste = x.Sjediste;
            karta.LetID = x.LetID;
            karta.Cijena = x.Cijena;
            karta.Aktivna = x.Aktivna;
           

            _dbContext.SaveChanges();
            return Ok(karta);
        }

        [HttpGet]
        public List<KartaGetAll2VM> GetAll(string filter)
        {
            var data = _dbContext.Karta.Where(x => filter == null || x.KartaID.ToString().ToLower().StartsWith(filter.ToLower()) )
                                                               
                .Select(s => new KartaGetAll2VM
                {
                    id = s.KartaID,
                    vrijemedolaska=s.Let.VrijemeDolaska.ToString(),
                    vrijemepolaska=s.Let.DatumVrijemePolaska.ToString(),
                    Cijena=s.Cijena,
                    Aktivna=s.Aktivna,
                    LetID=s.LetID,
                    Sjediste=s.Sjediste,
                    TipKarteID=s.TipKarteID,
                    tip=s.TipKarte.Naziv,
                    sifra=s.Let.SifraLeta
        }).AsQueryable();
            return data.Take(100).ToList();
        }

        [HttpGet]
        public ActionResult<PagedList<KartaGetAll2VM>> GetAllPaged(string filter, int page_number = 1)
        {
            var data = _dbContext.Karta.Where(x => filter == null || x.KartaID.ToString().ToLower().StartsWith(filter.ToLower()))

                .Select(s => new KartaGetAll2VM
                {
                    id = s.KartaID,
                    vrijemedolaska = s.Let.VrijemeDolaska.ToString(),
                    vrijemepolaska = s.Let.DatumVrijemePolaska.ToString(),
                    Cijena = s.Cijena,
                    Aktivna = s.Aktivna,
                    LetID = s.LetID,
                    Sjediste = s.Sjediste,
                    TipKarteID = s.TipKarteID,
                    tip = s.TipKarte.Naziv,
                    sifra = s.Let.SifraLeta
                }).AsQueryable();
            return PagedList<KartaGetAll2VM>.Create(data, page_number, 10);
        }

        [HttpGet]
        public List<KartaGetAll3VM> GetAllKupac(string filter ,string putanja, string polaziste, string destinacija, string dolazak, string polazak)
        {
            var data = _dbContext.Karta.Include(x=>x.Let).Include(x=>x.Let.Destinacija).Include(x=>x.Let.Polaziste)
                .Where(x => filter==null || (x.Putanja.Naziv.StartsWith(putanja) && x.Let.VrijemeDolaska.ToString().StartsWith(dolazak) && x.Let.DatumVrijemePolaska.ToString().StartsWith(polazak)))

                .Select(s => new KartaGetAll3VM
                {
                    id = s.KartaID,
                    vrijemeDolaska = s.Let.VrijemeDolaska.ToString(),
                    vrijemePolaska = s.Let.DatumVrijemePolaska.ToString(),
                    Cijena = s.Cijena,
                    Aktivna = s.Aktivna,
                    LetID = s.LetID,
                    Sjediste = s.Sjediste,
                    TipKarteID = s.TipKarteID,
                    tip = s.TipKarte.Naziv,
                    sifra = s.Let.SifraLeta,
                    polaziste=s.Let.Polaziste.Naziv,
                    destinacija=s.Let.Destinacija.Naziv,
                    putanja=s.Putanja.Naziv
                }).AsQueryable();
            return data.Take(100).ToList();
        }
        [HttpGet]
        public ActionResult<List<KartaGetAll3VM>> GetByLet(int id)
        {
            var s = _dbContext.Karta.Where(x => x.LetID == id)
                .Select(s => new KartaGetAll3VM
                {
                    id = s.KartaID,
                    vrijemeDolaska = s.Let.VrijemeDolaska.ToString(),
                    vrijemePolaska = s.Let.DatumVrijemePolaska.ToString(),
                    Cijena = s.Cijena,
                    Aktivna = s.Aktivna,
                    LetID = s.LetID,
                    Sjediste = s.Sjediste,
                    TipKarteID = s.TipKarteID,
                    tip = s.TipKarte.Naziv,
                    sifra = s.Let.SifraLeta,
                    polaziste = s.Let.Polaziste.Naziv,
                    destinacija = s.Let.Destinacija.Naziv,
                    putanja = s.Putanja.Naziv
                }).AsQueryable();

            return s.Take(100).ToList();
        }

        [HttpGet]
        public ActionResult<PagedList<KartaGetAll3VM>> GetByLetPaged(int id, int page_number = 1)
        {
            var s = _dbContext.Karta.Where(x => x.LetID == id)
                .Select(s => new KartaGetAll3VM
                {
                    id = s.KartaID,
                    vrijemeDolaska = s.Let.VrijemeDolaska.ToString(),
                    vrijemePolaska = s.Let.DatumVrijemePolaska.ToString(),
                    Cijena = s.Cijena,
                    Aktivna = s.Aktivna,
                    LetID = s.LetID,
                    Sjediste = s.Sjediste,
                    TipKarteID = s.TipKarteID,
                    tip = s.TipKarte.Naziv,
                    sifra = s.Let.SifraLeta,
                    polaziste = s.Let.Polaziste.Naziv,
                    destinacija = s.Let.Destinacija.Naziv,
                    putanja = s.Putanja.Naziv
                }).AsQueryable();

            return PagedList<KartaGetAll3VM>.Create(s,page_number,10);
        }
    }
    public class KartaGetAll2VM
    {
            public int id { get; set; }
        public string vrijemepolaska { get; set; }
        public string vrijemedolaska { get; set; }
        public float Cijena { get; set; }
        public bool Aktivna { get; set; }
        public string Sjediste { get; set; }
        public int? TipKarteID { get; set; }
        public string tip { get; set; }
        public int? LetID { get; set; }
        public string sifra { get; set; }

    }
    public class KartaGetAll3VM
    {
        public int id { get; set; }
        public string vrijemePolaska { get; set; }
        public string vrijemeDolaska { get; set; }
        public float Cijena { get; set; }
        public bool Aktivna { get; set; }
        public string Sjediste { get; set; }
        public int? TipKarteID { get; set; }
        public string tip { get; set; }
        public int? LetID { get; set; }
        public string sifra { get; set; }
        public string polaziste { get; set; }
        public string destinacija { get; set; }
       public string putanja { get; set; }


    }
}
