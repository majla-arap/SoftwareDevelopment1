using Microsoft.AspNetCore.Mvc;
using MilesAway.Data;
using MilesAway.Helper;
using MilesAway.Models;
using MilesAway.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MilesAway.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class KupacController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public KupacController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        [HttpPost]
        public Kupac Add([FromBody] kupac x)
        {
            var kupac = new Kupac
            {
                Ime = x.ime,
                Prezime = x.prezime,
            };

            _dbContext.Add(kupac);
            _dbContext.SaveChanges();
            return kupac;
        }

        [HttpPost("{id}")]
        public ActionResult Update(int id, [FromBody] kupac x)
        {
            Kupac kupac = _dbContext.Kupac.Find(id);

            if (kupac == null)
                return BadRequest("pogresan ID");

            kupac.Ime = x.ime;
            kupac.Prezime = x.prezime;


            _dbContext.SaveChanges();
            return Ok(kupac);
        }

        [HttpPost]
        public ActionResult Update([FromBody] kupac x)
        {
            var kor = HttpContext.GetLoginInfo()?.korisnickiNalog;
           

            if (kor == null)
                return BadRequest("pogresan ID");

            kor.Ime = x.ime;
            kor.Prezime = x.prezime;
            kor.lozinka = x.lozinka;
            kor.email = x.email;
            kor.korisnickoIme = x.korisnickoIme;

            _dbContext.SaveChanges();
            return Ok(kor);
        }

        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
            Kupac kupac = _dbContext.Kupac.Find(id);

            if (kupac == null)
                return BadRequest("pogresan ID");

            _dbContext.Remove(kupac);

            _dbContext.SaveChanges();
            return Ok(kupac);
        }

        [HttpGet]
        public ActionResult<KorisnikGetVM> GetByKupac()
        {
            var kor = HttpContext.GetLoginInfo()?.korisnickiNalog;
            if (kor == null)
                return BadRequest("Niste prijavljeni");
            var rezultat = new KorisnikGetVM
            {
                ime = kor.Ime,
                prezime = kor.Prezime,
                lozinka = kor.lozinka,
                email = kor.email,
                korisnickoIme = kor.korisnickoIme,
                slika = kor.slika_korisnika
            };
            return rezultat;
        }

        [HttpGet]
        public List<KupacGetAllVM> GetAll(string name)
        {
            var data = _dbContext.Kupac.Where(x => name == null || x.Ime.StartsWith(name)).OrderByDescending(s => s.KorisnikID)
                .Select(s => new KupacGetAllVM
                {
                    id = s.KorisnikID,
                    ime = s.Ime,
                    prezime = s.Prezime

                })
                .AsQueryable();
            return data.Take(100).ToList();
        }

    //    [HttpPost("{id}")]
    //public ActionResult AddProfileImage(int id, [FromForm] ObavijestSlikaAddVM x)
    //{

    //    try
    //    {
    //        Kupac kupac = _dbContext.Kupac.FirstOrDefault(s => s.KorisnikID == id);

    //        if (x.Slika != null && kupac != null)
    //            {
    //                if (x.Slika.Length > 300 * 1000)
    //                    return BadRequest("max velicina fajla je 300 KB");

    //                string ekstenzija = Path.GetExtension(x.Slika.FileName);

    //                var filename = $"{Guid.NewGuid()}{ekstenzija}";

    //                x.Slika.CopyTo(new FileStream(Config.SlikeFolder + filename, FileMode.Create));
    //                kupac.slika_korisnika = Config.SlikeURL + filename;
    //                _dbContext.SaveChanges();
    //            }

    //            return Ok(kupac);
    //        }
    //        catch (Exception ex)
    //            {
    //            return BadRequest(ex.Message + ex.InnerException);
    //         }
    //    }
    }
}
