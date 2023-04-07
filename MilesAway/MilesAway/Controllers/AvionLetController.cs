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
    public class AvionLetController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public AvionLetController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpPost]
        public AvionLet Add([FromBody] AvionLetAddVM x)
        {
            var noviAvionLet = new AvionLet
            {
                
                LetID = x.LetID,
                AvionID=x.AvionID
            };

            _dbContext.Add(noviAvionLet);
            _dbContext.SaveChanges();
            return noviAvionLet;
        }

        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
            AvionLet avionLet = _dbContext.AvionLet.Find(id);
        if (avionLet == null)
                return BadRequest("Pogresan ID");
            _dbContext.Remove(avionLet);
            _dbContext.SaveChanges();
            return Ok(avionLet);
        }

        [HttpPost("{id}")]
        public ActionResult Update(int id, [FromBody] AvionLetAddVM x)
        {
            AvionLet avionLet = _dbContext.AvionLet.Find(id);

            if (avionLet == null)
                return BadRequest("Pogresan ID");
            
            avionLet.LetID = x.LetID;
            avionLet.AvionID = x.AvionID;

            _dbContext.SaveChanges();
            return Ok(avionLet);
        }

        [HttpGet]
        public List<AvionLetGetAllVM> GetAll(string filter)
        {
            var data = _dbContext.AvionLet.Where(x => filter == null || x.Let.SifraLeta.ToLower().StartsWith(filter.ToLower())
                                                                        || x.Avion.BrojRegistracije.ToLower().StartsWith(filter.ToLower()))
                .Select(s => new AvionLetGetAllVM
                {
                    
                    SifraLeta = s.Let.SifraLeta,
                    Naziv=s.Avion.BrojRegistracije
                })
                .AsQueryable();
            return data.Take(100).ToList();
        }
        [HttpGet]
        public ActionResult<AvionLetGetVM> GetByLet(int id)
        {
            Let l = _dbContext.Let.Include(x => x.Destinacija).Include(x => x.Polaziste).SingleOrDefault(x => x.LetID == id);
            if (l == null)
                return BadRequest("pogresan ID");
            var result = new AvionLetGetVM
            {
                LetID = l.LetID,
                SifraLeta = l.SifraLeta,
                Polaziste = l.Polaziste.Naziv,
                Destinacija = l.Destinacija.Naziv,
               AvionLetGet = _dbContext.AvionLet.Include(x=>x.Avion)
                .Where(x => x.LetID == l.LetID).Select(x=>new AvionLetGet2VM
                {
                   Id=x.Id,
                   LetID=x.LetID,
                   AvionID=x.AvionID,
                   Avion=x.Avion.BrojRegistracije
                }).ToList(),
                Avion = _dbContext.Avion.ToList()

            };
            return result;
        }

    }
}
