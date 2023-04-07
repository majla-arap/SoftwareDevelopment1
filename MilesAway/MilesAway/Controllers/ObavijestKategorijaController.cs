using Microsoft.AspNetCore.Mvc;
using MilesAway.Data;
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
    public class ObavijestKategorijaController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public ObavijestKategorijaController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpPost]
        public ObavijestKategorije Add([FromBody] ObavijestKategorijaAddVM x)
        {
            var novaKategorija = new ObavijestKategorije
            {
                Naziv=x.Naziv
            };

            _dbContext.Add(novaKategorija);
            _dbContext.SaveChanges();
            return novaKategorija;
        }

        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
            List<Obavijest> obavijest = _dbContext.Obavijest.Where(x => x.ObavijestKategorijeID == id).ToList();
            _dbContext.RemoveRange(obavijest);
            _dbContext.SaveChanges();

            ObavijestKategorije kategorija = _dbContext.ObavijestKategorije.Find(id);

            if (kategorija == null)
                return BadRequest("Pogresan ID");

            _dbContext.Remove(kategorija);
            _dbContext.SaveChanges();
            return Ok(kategorija);
        }

        [HttpGet]
        public List<ObavijestKategorijeGetAllVM> GetByAll()
        {
            var data = _dbContext.ObavijestKategorije
                .OrderBy(s => s.Naziv)
                .Select(s => new ObavijestKategorijeGetAllVM()
                {
                    ObavijestKategorijeID = s.ObavijestKategorijeID,
                    Naziv=s.Naziv
                })
                .AsQueryable();
            return data.Take(100).ToList();
        }

        [HttpPost("{id}")]
        public ActionResult Update(int id, [FromBody] ObavijestKategorijaAddVM x)
        {
            ObavijestKategorije kategorija = _dbContext.ObavijestKategorije.Find(id);

            if (kategorija == null)
                return BadRequest("Pogresan ID");

            kategorija.Naziv = x.Naziv;

            _dbContext.SaveChanges();
            return Ok(kategorija);
        }
    }
}
