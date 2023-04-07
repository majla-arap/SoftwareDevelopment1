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
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class DrzavaController : ControllerBase
    {

        private readonly ApplicationDbContext _dbContext;

        public DrzavaController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
      

        [HttpPost]
        public ActionResult<Drzava> Add([FromBody] DrzavaAddVM x)
        {
            if (!HttpContext.GetLoginInfo().isPermisijaMenadzer)
                return BadRequest("nije logiran");

            var novaDrzava = new Drzava
            {
                Naziv = x.opis,
            };

            _dbContext.Add(novaDrzava);
            _dbContext.SaveChanges();
            return novaDrzava;
        }

        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
            List<KupljenaKarta>kupljenaKarta= _dbContext.KupljenaKarta.Where(x => x.Karta.Let.Polaziste.DrzavaID == id || x.Karta.Let.Destinacija.DrzavaID == id).ToList();
            _dbContext.RemoveRange(kupljenaKarta);
            _dbContext.SaveChanges();
            List<Karta> karta = _dbContext.Karta.Where(x => x.Let.Polaziste.DrzavaID== id || x.Let.Destinacija.DrzavaID==id).ToList();
            _dbContext.RemoveRange(karta);
            _dbContext.SaveChanges();
            List<AerodromLet> aerodromLet = _dbContext.AerodromLet.Where(x => x.Let.Destinacija.DrzavaID == id || x.Let.Polaziste.DrzavaID == id || x.Aerodrom1.Grad.DrzavaID == id || x.Aerodrom2.Grad.DrzavaID == id).ToList();
            _dbContext.RemoveRange(aerodromLet);
            _dbContext.SaveChanges();
            List<AvionLet> avionLet = _dbContext.AvionLet.Where(x => x.Let.Destinacija.DrzavaID == id || x.Let.Polaziste.DrzavaID == id).ToList();
            _dbContext.RemoveRange(avionLet);
            _dbContext.SaveChanges();
            List<PilotLet> pilotLet = _dbContext.PilotLet.Where(x => x.Let.Destinacija.DrzavaID == id || x.Let.Polaziste.DrzavaID == id).ToList();
            _dbContext.RemoveRange(pilotLet);
            _dbContext.SaveChanges();
            List<Presjedanje> presjedanje = _dbContext.Presjedanje.Where(x => x.Let.Destinacija.DrzavaID == id || x.Let.Polaziste.DrzavaID == id).ToList();
            _dbContext.RemoveRange(presjedanje);
            _dbContext.SaveChanges();
            List<Let> let = _dbContext.Let.Where(x => x.Destinacija.DrzavaID == id || x.Polaziste.DrzavaID==id).ToList();
            _dbContext.RemoveRange(let);
            _dbContext.SaveChanges();
            List<Aerodrom> aerodrom = _dbContext.Aerodrom.Where(x => x.Grad.DrzavaID == id).ToList();
            _dbContext.RemoveRange(aerodrom);
            _dbContext.SaveChanges();
            List<Grad> grad = _dbContext.Grad.Where(x => x.DrzavaID == id).ToList();
            _dbContext.RemoveRange(grad);
            _dbContext.SaveChanges();
            Drzava drzava = _dbContext.Drzava.Find(id);

            if (drzava == null)
                return BadRequest("pogresan ID");

            _dbContext.Remove(drzava);

            _dbContext.SaveChanges();
            return Ok(drzava);
        }

        [HttpGet]
        public List<CmbStavke> GetAll()
        {
            var data = _dbContext.Drzava
                .OrderBy(s => s.Naziv)
                .Select(s => new CmbStavke()
                {
                    id = s.DrzavaID,
                    opis = s.Naziv,
                })
                .AsQueryable();
            return data.Take(100).ToList();
        }
    }
}
