using Microsoft.AspNetCore.Mvc;
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
    [ApiController]
    [Route("[controller]/[action]")]
    public class TipKarteController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public TipKarteController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpPost]
        public ActionResult<TipKarte> Add([FromBody] TipKarteAddVM x)
        {
            if (!HttpContext.GetLoginInfo().isPermisijaMenadzer)
                return BadRequest("nije logiran");

            var tipKarte = new TipKarte
            {
                Naziv = x.Naziv,
                Cijena = x.Cijena,
                IsAktivan=x.Aktivan
            };

            _dbContext.Add(tipKarte);
            _dbContext.SaveChanges();
            return tipKarte;
        }

        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
            List<Karta> karta = _dbContext.Karta.Where(x => x.TipKarteID == id).ToList();
            _dbContext.RemoveRange(karta);
            _dbContext.SaveChanges();

            TipKarte tipKarte = _dbContext.TipKarte.Find(id);

            if (tipKarte == null)
                return BadRequest("Pogresan ID");

            _dbContext.Remove(tipKarte);
            _dbContext.SaveChanges();
            return Ok(tipKarte);
        }

        [HttpGet]
        public List<TipKarteGetAllVM> GetAll(string filter)
        {
            var data = _dbContext.TipKarte.Where(x => filter == null || x.Naziv.StartsWith(filter))
                .OrderByDescending(s => s.TipID)
                .Select(s => new TipKarteGetAllVM
                {
                    ID = s.TipID,
                    Naziv = s.Naziv,
                    Cijena = s.Cijena,
                    Aktivan=s.IsAktivan
                })
                .AsQueryable();
            return data.Take(100).ToList();
        }

        [HttpPost("{id}")]
        public ActionResult Update(int id, [FromBody] TipKarteAddVM x)
        {
            TipKarte tipKarte = _dbContext.TipKarte.Find(id);

            if (tipKarte == null)
                return BadRequest("Pogresan ID");

            tipKarte.Naziv = x.Naziv;
            tipKarte.Cijena = x.Cijena;
            tipKarte.IsAktivan = x.Aktivan;

            _dbContext.SaveChanges();
            return Ok(tipKarte);
        }
    }
}
