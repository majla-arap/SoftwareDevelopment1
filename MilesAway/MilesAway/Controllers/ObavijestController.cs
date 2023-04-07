using Microsoft.AspNetCore.Mvc;
using MilesAway.Data;
using MilesAway.Helper;
using MilesAway.Models;
using MilesAway.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;

namespace MilesAway.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ObavijestController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public ObavijestController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpPost]
        public Obavijest Add([FromBody] ObavijestAddVM x)
        {
            var novaObavijest = new Obavijest
            {
                Naslov = x.Naslov,
                PodNaslov = x.PodNaslov,
                Opis = x.Opis,
                DatumKreiranja = x.datum,
                ObavijestKategorijeID = x.ObavijestKategorijeID,
                Menadzer = HttpContext.GetLoginInfo()?.korisnickiNalog as Menadzer,
                MenadzerID= HttpContext.GetLoginInfo()?.korisnickiNalog.KorisnikID
            };
            _dbContext.Add(novaObavijest);
            _dbContext.SaveChanges();
            return novaObavijest;
        }


        [HttpPost("{id}")]
        public ActionResult AddImage(int id, IFormFile file)

        {
            try
            {
                Obavijest obavijest = _dbContext.Obavijest.Include(s => s.ObavijestKategorija).FirstOrDefault(s => s.ObavijestID == id);


                if (file != null && obavijest != null)
                {
                    var newSlika = ImageHelper.FileToByte(file);
                    if (newSlika != null)
                    {
                        obavijest.Slika_ = newSlika;
                    }
                    _dbContext.SaveChanges();
                }
                return Ok(obavijest);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ex.InnerException);
            }
        }



        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
            Obavijest obavijest = _dbContext.Obavijest.Find(id);
            
            if (obavijest == null)
                return BadRequest("Pogresan ID");

            _dbContext.Remove(obavijest);
            _dbContext.SaveChanges();
            return Ok(obavijest);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(_dbContext.Obavijest.FirstOrDefault(s => s.ObavijestID == id));
        }

        [HttpGet]
        public ActionResult<List<ObavijestGetVM>> GetAll(string filter)
        {
            var data = _dbContext.Obavijest
                .Include(s => s.ObavijestKategorija)
                .Include(s=>s.Menadzer)
                .Where(x => filter == null || x.Naslov.StartsWith(filter) 
                                           || x.PodNaslov.StartsWith(filter) 
                                           || x.Opis.StartsWith(filter))
                .Select(s => new ObavijestGetVM
                {
                    ObavijestID=s.ObavijestID,
                    ObavijestKategorijeID=s.ObavijestKategorijeID,
                    ObavijestKategorija=s.ObavijestKategorija,
                    Opis=s.Opis,
                    Slika_=ImageHelper.ByteToString(s.Slika_),
                    Naslov=s.Naslov,
                    PodNaslov=s.PodNaslov,
                    DatumKreiranja=s.DatumKreiranja,
                    Menadzer=s.Menadzer,
                    MenadzerID=s.MenadzerID
                })
                .AsQueryable();
            return data.Take(100).ToList();
        }

        [HttpGet]
        public ActionResult<PagedList<ObavijestGetVM>> GetAllPaged(string filter, int page_number = 1)
        {
            var data = _dbContext.Obavijest
                .Include(s => s.ObavijestKategorija)
                .Include(s => s.Menadzer)
                .Where(x => filter == null || x.Naslov.StartsWith(filter)
                                           || x.PodNaslov.StartsWith(filter)
                                           || x.Opis.StartsWith(filter))
                .Select(s => new ObavijestGetVM
                {
                    ObavijestID = s.ObavijestID,
                    ObavijestKategorijeID = s.ObavijestKategorijeID,
                    ObavijestKategorija = s.ObavijestKategorija,
                    Opis = s.Opis,
                    Slika_ = ImageHelper.ByteToString(s.Slika_),
                    Naslov = s.Naslov,
                    PodNaslov = s.PodNaslov,
                    DatumKreiranja = s.DatumKreiranja,
                    Menadzer = s.Menadzer,
                    MenadzerID = s.MenadzerID
                })
                .AsQueryable();
            return PagedList<ObavijestGetVM>.Create(data, page_number, 10);
        }

        [HttpPost("{id}")]
        public ActionResult Update(int id, [FromBody] ObavijestUpdateVM x)
        {
            Obavijest obavijest = _dbContext.Obavijest.FirstOrDefault(s => s.ObavijestID == id);

            if (obavijest == null)
                return BadRequest("Pogresan ID");

            obavijest.Naslov = x.Naslov;
            obavijest.PodNaslov = x.PodNaslov;
            obavijest.Opis = x.Opis;
            obavijest.DatumKreiranja = DateTime.Now;
            obavijest.ObavijestKategorijeID = x.ObavijestKategorijeID;
            obavijest.Menadzer = HttpContext.GetLoginInfo()?.korisnickiNalog as Menadzer;
            obavijest.MenadzerID = HttpContext.GetLoginInfo()?.korisnickiNalog.KorisnikID;
            _dbContext.SaveChanges();
            return Get(obavijest.ObavijestID);
        }
    }
}
