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
    public class PilotLetController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public PilotLetController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<PilotLetGetVM> GetByLet(int id)
        {
            Let l = _dbContext.Let.Include(x => x.Destinacija).Include(x => x.Polaziste).SingleOrDefault(x => x.LetID == id);
            if (l == null)
                return BadRequest("pogresan ID");
            var result = new PilotLetGetVM
            {
                LetID = l.LetID,
                SifraLeta = l.SifraLeta,
                Polaziste = l.Polaziste.Naziv,
                Destinacija = l.Destinacija.Naziv,
                // PilotLet = _dbContext.PilotLet.ToList(),
                PilotLetGet = _dbContext.PilotLet
                .Include(x => x.Pilot)
                .Where(x => x.LetID == id)
                .Select(x => new PilotLetGet2VM
                {
                    Id = x.Id,
                    LetID = x.LetID,
                    PilotID = x.PilotID,
                    Ime = x.Pilot.Ime,
                    Prezime = x.Pilot.Prezime,
                    BrojDozvole = x.Pilot.BrojDozvole,
                    SifraLeta = x.Let.SifraLeta
                })
                .ToList(),
                Piloti = _dbContext.Pilot.ToList()
            };
            return result;
        }

        [HttpPost]
        public PilotLet Add([FromBody] PilotLetAddVM x)
        {
            var noviPilotLet = new PilotLet
            {
                LetID = x.LetID,
                PilotID = x.PilotID
            };

            _dbContext.Add(noviPilotLet);
            _dbContext.SaveChanges();
            return noviPilotLet;
        }

        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
            PilotLet pilotLet = _dbContext.PilotLet.Find(id);
            if (pilotLet == null)
                return BadRequest("Pogresan ID");

            _dbContext.Remove(pilotLet);
            _dbContext.SaveChanges();
            return Ok(pilotLet);
        }

        [HttpPost("{id}")]
        public ActionResult Update(int id, [FromBody] PilotLetAddVM x)
        {
            PilotLet pilotLet = _dbContext.PilotLet.Find(id);

            if (pilotLet == null)
                return BadRequest("Pogresan ID");

            pilotLet.LetID = x.LetID;
            pilotLet.PilotID = x.PilotID;

            _dbContext.SaveChanges();
            return Ok(pilotLet);
        }

        [HttpGet]
        public List<PilotLetGetAllVM> GetAll(string filter)
        {
            var data = _dbContext.PilotLet.Where(x => filter == null || x.Let.SifraLeta.ToLower().StartsWith(filter.ToLower())
                                                                     || x.Pilot.Ime.ToLower().StartsWith(filter.ToLower())
                                                                     || x.Pilot.Prezime.ToLower().StartsWith(filter.ToLower()))
                .Select(s => new PilotLetGetAllVM
                {
                    ImePrezimePilota = s.Pilot.ToString(),
                    SifraLeta=s.Let.SifraLeta
                })
                .AsQueryable();
            return data.Take(100).ToList();
        }
    }
}
