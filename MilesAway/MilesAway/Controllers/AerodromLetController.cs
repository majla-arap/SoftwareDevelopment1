using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class AerodromLetController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public AerodromLetController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<AerodromLetGetVM> GetByLet(int id)
        {
            Let l = _dbContext.Let.Include(x=>x.Destinacija).Include(x=>x.Polaziste).SingleOrDefault(x => x.LetID == id);
            if (l == null)
                return BadRequest("pogresan ID");
            var result = new AerodromLetGetVM
            {
                LetID=l.LetID,
                SifraLeta=l.SifraLeta,
                Polaziste=l.Polaziste.Naziv,
                Destinacija=l.Destinacija.Naziv,
                AerodromLet=_dbContext.AerodromLet
                .Include(x=>x.Aerodrom1)
                .Include(x=>x.Aerodrom2)
                .Where(x=>x.LetID==id).ToList(),
                AerodromPolaska = _dbContext.Aerodrom
                .Include(x => x.Grad)
                .Where(x => x.GradID == l.PolazisteGradID).ToList(),
                AerodromDestinacije = _dbContext.Aerodrom
                .Include(x => x.Grad)
                .Where(x => x.GradID == l.DestinacijaGradID).ToList()
            };
            return result;
        }

        [HttpPost]
        public AerodromLet Add([FromBody] AerodromLetAddVM x)
        {
            var noviAerodromLet = new AerodromLet
            {
                LetID=x.LetID,
                AerodromID=x.AerodromID,
                AerodromID_ID=x.AerodromID_ID
            };

            _dbContext.Add(noviAerodromLet);
            _dbContext.SaveChanges();
            return noviAerodromLet;
        }

        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
            AerodromLet aerodromLet = _dbContext.AerodromLet.Find(id);

            if (aerodromLet == null)
                return BadRequest("Pogresan ID");

            _dbContext.Remove(aerodromLet);
            _dbContext.SaveChanges();
            return Ok(aerodromLet);
        }

        [HttpPost("{id}")]
        public ActionResult Update(int id, [FromBody] AerodromLetAddVM x)
        {
            AerodromLet aerodromLet = _dbContext.AerodromLet.Find(id);

            if (aerodromLet == null)
                return BadRequest("Pogresan ID");

            aerodromLet.LetID = x.LetID;
            aerodromLet.AerodromID = x.AerodromID;
            aerodromLet.AerodromID_ID = x.AerodromID_ID;

            _dbContext.SaveChanges();
            return Ok(aerodromLet);
        }

        [HttpGet]
        public List<AerodromLetGetAllVM> GetAll(string filter)
        {
            var data = _dbContext.AerodromLet.Where(x => filter == null ||x.Let.SifraLeta.ToLower().StartsWith(filter.ToLower())
                                                                        ||x.Aerodrom1.Naziv.ToLower().StartsWith(filter.ToLower())
                                                                        ||x.Aerodrom2.Naziv.ToLower().StartsWith(filter.ToLower()))                                                       
                .Select(s => new AerodromLetGetAllVM
                {
                    SifraLeta = s.Let.SifraLeta,
                    AerodromNaziv1 = s.Aerodrom1.Naziv,
                    AerodromNaziv2 = s.Aerodrom2.Naziv,
                })
                .AsQueryable();
            return data.Take(100).ToList();
        }
    }
}
