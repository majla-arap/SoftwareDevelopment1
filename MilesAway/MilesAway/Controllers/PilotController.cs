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
    public class PilotController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public PilotController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpPost]
        public ActionResult<Pilot> Add([FromBody] PilotAddVM x)
        {
            if (!HttpContext.GetLoginInfo().isPermisijaMenadzer)
                return BadRequest("nije logiran");

            var noviPilot = new Pilot
            {
                Ime=x.Ime,
                Prezime=x.Prezime,
                DatumRodjenja=x.DatumRodjenja,
                DatumZaposlenja=x.DatumZaposlenja,
                Spol=x.Spol,
                JMBG=x.JMBG,
                BrojDozvole=x.BrojDozvole,
                Kontakt=x.Kontakt,
                Adresa=x.Adresa
            };

            _dbContext.Add(noviPilot);
            _dbContext.SaveChanges();
            return noviPilot;
        }

        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
            List<PilotLet> pilotLet = _dbContext.PilotLet.Where(x => x.PilotID == id).ToList();
            //if(pilotLet!=null)
            //{
                _dbContext.RemoveRange(pilotLet);
                _dbContext.SaveChanges();
            //}
            

            Pilot pilot = _dbContext.Pilot.Find(id);

            if (pilot == null)
                return BadRequest("Pogresan ID");


            _dbContext.Remove(pilot);
            _dbContext.SaveChanges();
            return Ok(pilot);
        }

        [HttpPost("{id}")]
        public ActionResult Update(int id, [FromBody] PilotAddVM x)
        {
            Pilot pilot = _dbContext.Pilot.Find(id);

            if (pilot == null)
                return BadRequest("Pogresan ID");

            pilot.Ime = x.Ime;
            pilot.Prezime = x.Prezime;
            pilot.BrojDozvole = x.BrojDozvole;
            pilot.DatumRodjenja = x.DatumRodjenja;
            pilot.DatumZaposlenja = x.DatumZaposlenja;
            pilot.Spol = x.Spol;
            pilot.JMBG = x.JMBG;
            pilot.Kontakt = x.Kontakt;
            pilot.Adresa = x.Adresa;

            _dbContext.SaveChanges();
            return Ok(pilot);
        }

        [HttpGet]
        public ActionResult<List<Pilot>> GetAll(string filter)
        {
            var data = _dbContext.Pilot.Where(x => filter == null || x.Ime.ToLower().StartsWith(filter.ToLower())
                                                                  || x.Prezime.ToLower().StartsWith(filter.ToLower())
                                                                  || x.BrojDozvole.ToLower().StartsWith(filter.ToLower()))
                .Select(s => new Pilot
                {
                    PilotID=s.PilotID,
                    Ime = s.Ime,
                    Prezime = s.Prezime,
                    DatumRodjenja = s.DatumRodjenja,
                    DatumZaposlenja = s.DatumZaposlenja,
                    Spol = s.Spol,
                    JMBG = s.JMBG,
                    BrojDozvole = s.BrojDozvole,
                    Kontakt = s.Kontakt,
                    Adresa = s.Adresa
                })
                .AsQueryable();
            return data.Take(100).ToList();
        }
    }

}
