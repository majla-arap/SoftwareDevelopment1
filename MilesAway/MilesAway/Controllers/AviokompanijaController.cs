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
    public class AviokompanijaController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public AviokompanijaController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
      
        [HttpPost]
        public ActionResult<Aviokompanija> Add([FromBody] AviokompanijaAddVM x)
        {
            if (!HttpContext.GetLoginInfo().isPermisijaMenadzer)
                return BadRequest("nije logiran");

            var ak = new Aviokompanija
            {
                Naziv = x.opis,
            };

            _dbContext.Add(ak);
            _dbContext.SaveChanges();
            return ak;
        }

       
        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
            List<AvionLet> avionLet = _dbContext.AvionLet.Where(x => x.Avion.AviokompanijaID == id).ToList();
            _dbContext.RemoveRange(avionLet);
            _dbContext.SaveChanges();
            List<Avion> avion = _dbContext.Avion.Where(x => x.AviokompanijaID == id).ToList();
            _dbContext.RemoveRange(avion);
            _dbContext.SaveChanges();
            Aviokompanija ak = _dbContext.Aviokompanija.Find(id);

            if (ak == null)
                return BadRequest("pogresan ID");

            _dbContext.Remove(ak);

            _dbContext.SaveChanges();
            return Ok(ak);
        }
        [HttpGet]
        public ActionResult<List<CmbStavke>> GetAll()
        {
            var data = _dbContext.Aviokompanija
                .OrderBy(s => s.Naziv)
                .Select(s => new CmbStavke()
                {
                    id = s.AviokompanijaID,
                    opis =s.Naziv
                })
                .AsQueryable();
            return data.Take(100).ToList();
        }
    }
}
