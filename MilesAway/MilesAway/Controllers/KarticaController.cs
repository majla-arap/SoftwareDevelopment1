using Microsoft.AspNetCore.Mvc;
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
    public class KarticaController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public KarticaController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
      
        [HttpPost]
        public Kartica Add([FromBody] KarticaAddVM x)
        {
            

            
            var newKartica = new Kartica
            {
                BrojKartice = x.brojKartice,
                DatumIsteka = x.datumIsteka,
                VerifikacijskiKod = x.verifikacijskiKod,
                KupacID=x.Id

            };

            _dbContext.Add(newKartica);
            _dbContext.SaveChanges();
            return newKartica;
        }
        //[HttpPost]
        //public Kartica AddByKupac([FromBody] KarticaAdd2VM x)
        //{
        //    //var korisnik = HttpContext.GetLoginInfo()?.korisnickiNalog;


        //    var newKartica = new Kartica
        //    {
        //        BrojKartice = x.brojKartice,
        //        DatumIsteka = x.datumIsteka,
        //        VerifikacijskiKod = x.verifikacijskiKod,
        //        KupacID = x.Id,
        //        evidentiraoKorisnik= HttpContext.GetLoginInfo()?.korisnickiNalog,
        //        imeVlasnika =x.imevlasnika
        //    };

        //    _dbContext.Add(newKartica);
        //    _dbContext.SaveChanges();
        //    return newKartica;
        //}
        [HttpPost]
        public ActionResult AddByKupac([FromBody] KarticaAdd2VM x)
        {
            //if (!HttpContext.GetLoginInfo().isPermisijaProdekan)
            //    return BadRequest("nije logiran");

            var novi = new Kartica();
            _dbContext.Add(novi);

            novi.DatumIsteka = x.datumIsteka;           
            novi.VerifikacijskiKod = x.verifikacijskiKod;
            novi.imeVlasnika = x.imevlasnika;
            novi.BrojKartice = x.brojKartice;
            novi.Kupac = HttpContext.GetLoginInfo()?.korisnickiNalog as Kupac;
            novi.KupacID = 1;
            _dbContext.SaveChanges();

            return Ok(novi.KarticaID);
        }

        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {

            Kartica kartica = _dbContext.Kartica.Find(id);

            if (kartica == null)
                return BadRequest("pogresan ID");

            _dbContext.Remove(kartica);

            _dbContext.SaveChanges();
            return Ok(kartica);
        }
        [HttpGet]
        public List<KarticaGetAllVM> GetAll(int id)
        {
            var data = _dbContext.Kartica.Where(x => id == null || x.KupacID==id).OrderByDescending(s => s.KarticaID)
                .Select(s => new KarticaGetAllVM
                {
                     Id= s.KarticaID,
                    brojKartice = s.BrojKartice,
                    datumIsteka = s.DatumIsteka,
                    verifikacijskiKod = s.VerifikacijskiKod,
                    imeVlasnika=s.Kupac.ToString()
                    

                })
                .AsQueryable();
            return data.Take(100).ToList();
        }
        [HttpGet]
        public ActionResult<KarticaGetAllByKupacVM> GetByKupac()
        {

            var korisnik = HttpContext.GetLoginInfo()?.korisnickiNalog;
            if (korisnik == null)
                return BadRequest("Niste prijavljeni");

            var result = new KarticaGetAllByKupacVM
            {
                imeVlasnika = korisnik.korisnickoIme,
                Kartica = _dbContext.Kartica.Include(x => x.Kupac).Where(x => x.KupacID == korisnik.KorisnikID).ToList()
            };

            //var data = _dbContext.Kartica.Include(x=>x.Kupac).Where(x => x.KupacID == korisnik.KorisnikID)
            //    .Select(s => new KarticaGetAllByKupacVM
            //    {
            //        Id=s.KarticaID,
            //        imeVlasnika=s.Kupac.ToString(),
            //        brojKartice=s.BrojKartice,
            //        verifikacijskiKod=s.VerifikacijskiKod,
            //        datumIsteka=s.DatumIsteka
            //    }).AsQueryable();
            return result;
        }

        //[HttpGet]
        //public ActionResult<KarticaGetAllByKupacVM> GetByKupac(int id)
        //{
        //    //if (!HttpContext.GetLoginInfo().isPermisijaStudentskaSluzba)
        //    //    return BadRequest("nije logiran");

        //    Kartica s = _dbContext.Kartica
        //        .Include(x => x.Kupac)
        //        .SingleOrDefault(x => x.KupacID == id);

        //    if (s == null)
        //        return BadRequest("pogresan ID");

        //    var result = new KarticaGetAllByKupacVM
        //    {

        //        Id = s.KarticaID,
        //        imeVlasnika = s.Kupac.ToString(),
        //        brojKartice = s.BrojKartice,
        //        verifikacijskiKod = s.VerifikacijskiKod,
        //        datumIsteka = s.DatumIsteka
        //    };

        //    return result;
        //}
    }

 
}
public class KarticaGetAllByKupacVM
{
    public string imeVlasnika { get; set; }
    public List<Kartica> Kartica { get; set; }
}

public class KarticaAdd2VM
{
    internal int? kupacID;

    public string brojKartice { get; set; }
    public DateTime datumIsteka { get; set; }
    public int verifikacijskiKod { get; set; }

    public int Id { get; set; }
    public string imevlasnika { get; set; }
}