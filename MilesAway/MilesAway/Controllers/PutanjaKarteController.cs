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
    public class PutanjaKarteController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public PutanjaKarteController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        [HttpPost]
        public ActionResult<VrstaPutanjeKarte> Add([FromBody] CmbStavke x)
        {
            //if (!HttpContext.GetLoginInfo().isPermisijaMenadzer)
            //    return BadRequest("nije logiran");

            var putanja = new VrstaPutanjeKarte
            {
                Naziv = x.opis,
            };

            _dbContext.Add(putanja);
            _dbContext.SaveChanges();
            return putanja;
        }

        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
        
          
            VrstaPutanjeKarte karta = _dbContext.VrstaPutanjeKarte.Find(id);

            if (karta == null)
                return BadRequest("pogresan ID");

            _dbContext.Remove(karta);

            _dbContext.SaveChanges();
            return Ok(karta);
        }

        [HttpGet]
        public List<CmbStavke> GetAll()
        {
            var data = _dbContext.VrstaPutanjeKarte
                .OrderBy(s => s.Naziv)
                .Select(s => new CmbStavke()
                {
                    id = s.PutanjaID,
                    opis = s.Naziv,
                })
                .AsQueryable();
            return data.Take(100).ToList();
        }
    
}
}
