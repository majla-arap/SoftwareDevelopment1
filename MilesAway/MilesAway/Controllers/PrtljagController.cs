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
    public class PrtljagController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public PrtljagController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpPost]
        public ActionResult<TipPrtljage> Add([FromBody] PrtljagAddVM x)
        {
            if (!HttpContext.GetLoginInfo().isPermisijaMenadzer)
                return BadRequest("nije logiran");

            var prtljag = new TipPrtljage
            {
               Naziv=x.naziv,
               CijenaDodatak=x.dodatak
            };

            _dbContext.Add(prtljag);
            _dbContext.SaveChanges();
            return prtljag;
        }

        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
            List<KupljenaKarta> kupljenaKarta = _dbContext.KupljenaKarta.Where(x => x.TipPrtljageID == id).ToList();
            _dbContext.RemoveRange(kupljenaKarta);
            _dbContext.SaveChanges();

            TipPrtljage prtljag = _dbContext.TipPrtljage.Find(id);

            if (prtljag == null)
                return BadRequest("pogresan ID");

            _dbContext.Remove(prtljag);

            _dbContext.SaveChanges();
            return Ok(prtljag);
        }

        [HttpGet]
        public ActionResult<List<PrtljagGetAllVM>> GetAll(string name)
        {
            var data = _dbContext.TipPrtljage.Where(x => name == null || x.Naziv.ToLower().StartsWith(name)).OrderByDescending(s => s.TipID)
                .Select(s => new PrtljagGetAllVM
                {
                    id = s.TipID,
                    naziv = s.Naziv,
                    dodatak = s.CijenaDodatak,
                })
                .AsQueryable();
            return data.Take(100).ToList();
        }
    }

   
}
