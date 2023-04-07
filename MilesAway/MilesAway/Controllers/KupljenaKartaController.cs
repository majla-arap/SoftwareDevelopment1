using Microsoft.AspNetCore.Mvc;
using MilesAway.Data;
using MilesAway.Helper;
using MilesAway.Helper.Email;
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
    public class KupljenaKartaController: Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IEmail _email;

        public KupljenaKartaController(ApplicationDbContext dbContext, IEmail email)
        {
            this._dbContext = dbContext;
            _email = email;
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] KupljenaKartaAddVM x)
        {
            var karta = _dbContext.Karta.Find(x._KartaID);
            var prtljaga = _dbContext.TipPrtljage.Find(x.TipPrtljageID);
            var putnik = _dbContext.TipPutnika.Find(x.TipPutnikaID);
            var let = _dbContext.Let.Find(karta.LetID);
            var korinik = HttpContext.GetLoginInfo()?.korisnickiNalog as Kupac;
            KupljenaKarta nova;
            try
            {
                nova = new KupljenaKarta
                {
                    DatumKupovine = x._DatumKupovine,
                    IsAktivna = x._IsAktivna,
                    KartaID = x._KartaID,
                    KupacID = korinik.KorisnikID,
                    PostojiPopust = x._PostojiPopust,
                    TipPrtljageID = x.TipPrtljageID,
                    TipPutnikaID = x.TipPutnikaID,
                    Cijena = karta.Cijena + prtljaga.CijenaDodatak + putnik.Cijena,
                    DatumPolaska = let.DatumVrijemePolaska
                    //dodati datum povratka
                    

               };
                _dbContext.Add(nova);
                _dbContext.SaveChanges();
                await _email.Send("Kupili ste kartu", "Uspjesno ste izvrsili kupovinu karte", korinik.email, korinik.Ime);
                return Ok(nova);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message + ex.InnerException);
            }

            
        }
        [HttpGet]
        public List<KupljenaKartaGetAllVM> GetAll(string filter)
        {
            var data = _dbContext.KupljenaKarta.Where(x => filter == null || x.KupljenaKartaID.ToString().ToLower().StartsWith(filter.ToLower()))

                .Select(s => new KupljenaKartaGetAllVM
                {
                    id=s.KupljenaKartaID,
                    _DatumKupovine=s.DatumKupovine,
                    _IsAktivna=s.IsAktivna,
                    _KartaID=s.KartaID,
                    _KupacID=s.KupacID,
                    _PostojiPopust=s.PostojiPopust

                }).AsQueryable();
            return data.Take(100).ToList();
        }

        [HttpGet]
        public ActionResult<List<KupljenaKartaGetAllByKupacVM>> GetByKupac()
        {
            var korisnik=HttpContext.GetLoginInfo()?.korisnickiNalog;
            if (korisnik == null)
                return BadRequest("Niste prijavljeni");
            var data = _dbContext.KupljenaKarta.Where(x => x.KupacID == korisnik.KorisnikID)
                .Select(s => new KupljenaKartaGetAllByKupacVM
                {
                    DatumKupovine = s.DatumKupovine.Day.ToString() + "." + s.DatumKupovine.Month.ToString() + "." + s.DatumKupovine.Year.ToString(),
                    Polaziste = s.Karta.Let.Polaziste.Naziv,
                    Destinacija = s.Karta.Let.Destinacija.Naziv,
                    SifraLeta = s.Karta.Let.SifraLeta,
                    Cijena = s.Cijena,
                    Sjediste=s.Karta.Sjediste,
                    TipKarte=s.Karta.TipKarte.Naziv,
                    DatumPolaska=s.DatumPolaska.Day.ToString() + "." + s.DatumPolaska.Month.ToString() + "." + s.DatumPolaska.Year.ToString(),
                    DatumPovratka =s.DatumPovratka,
                    TipPrtljage=s.TipPrtljage.Naziv,
                    TipPutnika=s.TipPutnika.Naziv,
                    Popust=s.Popust.Naziv
                }).AsQueryable();
            return data.Take(100).ToList();
        }

        [HttpGet]
        public ActionResult<PagedList<KupljenaKartaGetAllByKupacVM>> GetByKupacPaged( int page_number = 1)
        {
            var korisnik = HttpContext.GetLoginInfo()?.korisnickiNalog;
            if (korisnik == null)
                return BadRequest("Niste prijavljeni");
            var k = _dbContext.KupljenaKarta.Where(x => x.KupacID == korisnik.KorisnikID)
                .Select(k=> new KupljenaKartaGetAllByKupacVM
                {
                    DatumKupovine = k.DatumKupovine.Day.ToString() + "." + k.DatumKupovine.Month.ToString() + "." + k.DatumKupovine.Year.ToString(),
                    Polaziste = k.Karta.Let.Polaziste.Naziv,
                    Destinacija = k.Karta.Let.Destinacija.Naziv,
                    SifraLeta = k.Karta.Let.SifraLeta,
                    Cijena = k.Cijena,
                    Sjediste = k.Karta.Sjediste,
                    TipKarte = k.Karta.TipKarte.Naziv,
                    DatumPolaska = k.DatumPolaska.Day.ToString() + "." + k.DatumPolaska.Month.ToString() + "." + k.DatumPolaska.Year.ToString(),
                    DatumPovratka = k.DatumPovratka,
                    TipPrtljage = k.TipPrtljage.Naziv,
                    TipPutnika = k.TipPutnika.Naziv,
                    Popust = k.Popust.Naziv
                }).AsQueryable();
            
       

            return PagedList<KupljenaKartaGetAllByKupacVM>.Create(k, page_number, 10);
        }

    }
}
