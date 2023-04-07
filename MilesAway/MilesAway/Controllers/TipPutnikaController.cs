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
    public class TipPutnikaController:ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public TipPutnikaController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpPost]
        public ActionResult<TipPutnika> Add([FromBody] TipPutnikaAddVM x)
        {
            if (!HttpContext.GetLoginInfo().isPermisijaMenadzer)
                return BadRequest("nije logiran");

            var tipPutnika = new TipPutnika
            {
                Naziv = x.Naziv,
                Cijena = x.Cijena
            };

            _dbContext.Add(tipPutnika);
            _dbContext.SaveChanges();
            return tipPutnika;
        }

        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
            List<KupljenaKarta> kupljenaKarta = _dbContext.KupljenaKarta.Where(x => x.TipPutnikaID == id).ToList();
            _dbContext.RemoveRange(kupljenaKarta);
            _dbContext.SaveChanges();

            TipPutnika tipPutnika = _dbContext.TipPutnika.Find(id);

            if (tipPutnika == null)
                return BadRequest("Pogresan ID");

            _dbContext.Remove(tipPutnika);
            _dbContext.SaveChanges();
            return Ok(tipPutnika);
        }

        [HttpGet]
        public ActionResult<List<TipPutnikaGetAllVM>> GetAll(string filter)
        {
            var data = _dbContext.TipPutnika.Where(x => filter == null || x.Naziv.StartsWith(filter))
                .OrderByDescending(s => s.TipID)
                .Select(s => new TipPutnikaGetAllVM
                {
                    ID = s.TipID,
                    Naziv = s.Naziv,
                    Cijena = s.Cijena
                })
                .AsQueryable();
            return data.Take(100).ToList();
        }

        [HttpPost("{id}")]
        public ActionResult Update(int id, [FromBody] TipPutnikaAddVM x)
        {
            TipPutnika tipPutnika = _dbContext.TipPutnika.Find(id);

            if (tipPutnika == null)
                return BadRequest("Pogresan ID");

            tipPutnika.Naziv = x.Naziv;
            tipPutnika.Cijena = x.Cijena;

            _dbContext.SaveChanges();
            return Ok(tipPutnika);
        }
    }
}
