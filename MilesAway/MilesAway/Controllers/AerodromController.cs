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
    public class AerodromController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public AerodromController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpPost]
        public ActionResult<Aerodrom> Add([FromBody] AerodromAddVM x)
        {
            if (!HttpContext.GetLoginInfo().isPermisijaMenadzer)
                return BadRequest("nije logiran");
       
            var noviAerodrom = new Aerodrom
            {
                Naziv = x.Naziv,
                GradID = x.GradID,
            };

            _dbContext.Add(noviAerodrom);
            _dbContext.SaveChanges();
            return noviAerodrom;
        }

        //[HttpGet]
        //public List<AerodromGetVM> GetByGrad(int GradID)
        //{
        //    var data = _dbContext.Aerodrom.Where(x => x.GradID == GradID)
        //        .OrderBy(s => s.Naziv)
        //        .Select(s => new AerodromGetVM()
        //        {
        //            AerodromID = s.AerodromID,
        //            Naziv = s.Naziv,
        //            Grad = s.Grad.Naziv
        //        })
        //        .AsQueryable();
        //    return data.Take(100).ToList();
        //}

        [HttpGet]
        public ActionResult<List<AerodromGetVM>> GetByGradString(string grad)
        {
            var data = _dbContext.Aerodrom.Where(x => grad == null || x.Grad.Naziv.ToLower().StartsWith(grad.ToLower()))
                .OrderBy(s => s.Naziv)
                .Select(s => new AerodromGetVM()
                {
                    AerodromID = s.AerodromID,
                    Naziv = s.Naziv,
                    Grad = s.Grad.Naziv
                })
                .AsQueryable();
            return data.Take(100).ToList();
        }

        [HttpGet]
        public ActionResult<List<AerodromGetVM>> GetAll()
        {
            var data = _dbContext.Aerodrom
                .OrderBy(s => s.Naziv)
                .Select(s => new AerodromGetVM()
                {
                    AerodromID = s.AerodromID,
                    Naziv = s.Naziv,
                    Grad = s.Grad.Naziv
                })
                .AsQueryable();
            return data.Take(100).ToList();
        }

        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
            List<AerodromLet> aerodromLet = _dbContext.AerodromLet.Where(x => x.AerodromID == id || x.AerodromID_ID == id).ToList();
            if (aerodromLet != null)
            {
                _dbContext.RemoveRange(aerodromLet);
                _dbContext.SaveChanges();
            }

            Aerodrom aerodrom = _dbContext.Aerodrom.Find(id);

            if (aerodrom == null)
                return BadRequest("Pogresan ID");

            _dbContext.Remove(aerodrom);
            _dbContext.SaveChanges();
            return Ok(aerodrom);
        }
    }
}
