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
    public class IzvjestajController : ControllerBase
    {
        /*private readonly ApplicationDbContext _dbContext;

        public IzvjestajController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        [HttpPost]
        public Izvjestaj Add([FromBody] IzvjestajAddVM x)
        {
            var novi = new Izvjestaj
            {
                Sadrzaj=x.sadrzaj,
                Datum=x.datum,
                MenadzerID=x.Menadzer_ID
            };

            _dbContext.Add(novi);
            _dbContext.SaveChanges();
            return novi;
        }

        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
            
         

            Izvjestaj izv = _dbContext.Izvjestaj.Find(id);

            if (izv == null)
                return BadRequest("pogresan ID");

            _dbContext.Remove(izv);

            _dbContext.SaveChanges();
            return Ok(izv);

        }

        [HttpPost("{id}")]
        public ActionResult Update(int id, [FromBody] IzvjestajAddVM x)
        {
            Izvjestaj Iz = _dbContext.Izvjestaj.Find(id);

            if (Iz == null)
                return BadRequest("Pogresan ID");

            Iz.Sadrzaj = x.sadrzaj;
            Iz.Datum = x.datum;
            Iz.MenadzerID = x.Menadzer_ID;
           

            _dbContext.SaveChanges();
            return Ok(Iz);
        }

        [HttpGet]
        public List<IzvjestajGetAllVM> GetAll(string filter)
        {
            var data = _dbContext.Izvjestaj.Where(x => filter == null || x.Menadzer.ToString().ToLower().StartsWith(filter.ToLower()))
                .Select(s => new IzvjestajGetAllVM
                {
                  id=s.IzvjestajID,
                  Sadrzaj=s.Sadrzaj,
                  Datum=s.Datum,
                  MenadzerID=s.MenadzerID.Value
                })
                .AsQueryable();
            return data.Take(100).ToList();
        }*/
    }

}

