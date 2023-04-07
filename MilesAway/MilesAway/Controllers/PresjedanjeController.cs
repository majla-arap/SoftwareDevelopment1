using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class PresjedanjeController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public PresjedanjeController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public ActionResult<Presjedanje> Add([FromBody] PresjedanjeAddVM x)
        {
            if (!HttpContext.GetLoginInfo().isPermisijaMenadzer)
                return BadRequest("nije logiran");

            var presjedanje = new Presjedanje
            {
                LetID=x.LetID,
                GradID=x.GradID,
                VrijemeDolaska=x.VrijemeDolaska,
                VrijemePolaska=x.VrijemePolaska
            };

            _dbContext.Add(presjedanje);
            _dbContext.SaveChanges();
            return presjedanje;
        }

        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {

            Presjedanje presjedanje = _dbContext.Presjedanje.Find(id);

            if (presjedanje == null)
                return BadRequest("Pogresan ID");

            _dbContext.Remove(presjedanje);
            _dbContext.SaveChanges();
            return Ok(presjedanje);
        }

        /*[HttpGet("{id}")]
        public ActionResult GetByLetID(int id)
        {
            return Ok(_dbContext.Presjedanje.Where(s =>s.LetID==id));
        }*/

        [HttpGet]
        public ActionResult<List<PresjedanjeGetVM>> GetAll(string sifra)
        {

            var data = _dbContext.Presjedanje.Where(x=>sifra==null || x.Let.SifraLeta.ToLower().StartsWith(sifra.ToLower()))
                .Select(s => new PresjedanjeGetVM()
                {
                    ID = s.PresjedanjeID,
                    Grad = s.MjestoPresjedanja.Naziv,
                    SifraLeta = s.Let.SifraLeta,
                    VrijemeDolaska = s.VrijemeDolaska,
                    VrijemePolaska = s.VrijemePolaska
                })
                  .AsQueryable();
            return data.Take(100).ToList();
        }

        [HttpPost("{id}")]
        public ActionResult Update(int id, [FromBody] PresjedanjeAddVM x)
        {
            Presjedanje presjedanje = _dbContext.Presjedanje.Find(id);
            //Presjedanje presjedanje = _dbContext.Presjedanje.Include(s=>s.Let).FirstOrDefault(s=>s.PresjedanjeID==id);

            if (presjedanje == null)
                return BadRequest("Pogresan ID");

            presjedanje.LetID = x.LetID;
            presjedanje.GradID = x.GradID;
            presjedanje.VrijemeDolaska = x.VrijemeDolaska;
            presjedanje.VrijemePolaska = x.VrijemePolaska;
            _dbContext.SaveChanges();
            return Ok(presjedanje);
        }
    }
}
