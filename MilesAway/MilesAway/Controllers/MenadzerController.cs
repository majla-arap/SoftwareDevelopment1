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
    public class MenadzerController :Controller
    {
            private readonly ApplicationDbContext _dbContext;

            public MenadzerController(ApplicationDbContext dbContext)
            {
                this._dbContext = dbContext;
            }


            [HttpPost]
            public Menadzer Add([FromBody] MenadzerAddVM x)
            {
                var men = new Menadzer
                {
                    Ime = x.ime,
                    Prezime = x.prezime,
                    DatumZaposlenja=x.datumZaposlenja,
                    Adresa=x.adresa,
                    BrojTelefona=x.brojTelefona

                };

                _dbContext.Add(men);
                _dbContext.SaveChanges();
                return men;
            }

            [HttpPost("{id}")]
            public ActionResult Update(int id, [FromBody] MenadzerAddVM x)
            {
                Menadzer menadzer = _dbContext.Menadzer.Find(id);

                if (menadzer == null)
                    return BadRequest("pogresan ID");

                menadzer.Ime = x.ime;
                menadzer.Prezime = x.prezime;


                _dbContext.SaveChanges();
                return Ok(menadzer);
            }

            [HttpPost("{id}")]
            public ActionResult Delete(int id)
            {
                Menadzer menadzer = _dbContext.Menadzer.Find(id);


                if (menadzer == null)
                    return BadRequest("pogresan ID");

                _dbContext.Remove(menadzer);

                _dbContext.SaveChanges();
                return Ok(menadzer);
            }

            [HttpGet]
            public List<MenadzerGetAll> GetAll(string name)
            {
                var data = _dbContext.Menadzer.Where(x => name == null || x.Ime.StartsWith(name)).OrderByDescending(s => s.KorisnikID)
                    .Select(s => new MenadzerGetAll
                    {
                        id = s.KorisnikID,
                        ime = s.Ime,
                        prezime = s.Prezime,
                        adresa=s.Adresa,
                        brojTelefona=s.BrojTelefona,
                        datumZaposlenja=s.DatumZaposlenja

                    })
                    .AsQueryable();
                return data.Take(100).ToList();
            }

            //[HttpPost("{id}")]
            //public ActionResult AddProfileImage(int id, [FromForm] ObavijestSlikaAddVM x)
            //{

            //    try
            //    {
            //        Menadzer mena = _dbContext.Menadzer.FirstOrDefault(s => s.KorisnikID == id);

            //        if (x.Slika != null && mena != null)
            //        {
            //            if (x.Slika.Length > 300 * 1000)
            //                return BadRequest("max velicina fajla je 300 KB");

            //            string ekstenzija = Path.GetExtension(x.Slika.FileName);

            //            var filename = $"{Guid.NewGuid()}{ekstenzija}";

            //            x.Slika.CopyTo(new FileStream(Config.SlikeFolder + filename, FileMode.Create));
            //            mena.slika_korisnika = Config.SlikeURL + filename;
            //            _dbContext.SaveChanges();
            //        }

            //        return Ok(mena);
            //    }
            //    catch (Exception ex)
            //    {
            //        return BadRequest(ex.Message + ex.InnerException);
            //    }
            //}
        }
    }

