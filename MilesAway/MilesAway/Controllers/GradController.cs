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
    public class GradController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public GradController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
      
        [HttpPost]
        public ActionResult<Grad> Add([FromBody] GradAddVM x)
        {
            if (!HttpContext.GetLoginInfo().isPermisijaMenadzer)
                return BadRequest("nije logiran");

            var grad = new Grad
            {
                Naziv = x.opis,
                DrzavaID = x.DrzavaID,
            };

            _dbContext.Add(grad);
            _dbContext.SaveChanges();
            return grad;
        }

        [HttpGet]
        public List<CmbStavke> GetByDrzava(int drzava_id)
        {
            var data = _dbContext.Grad.Where(x => x.DrzavaID == drzava_id)
                .OrderBy(s => s.Naziv)
                .Select(s => new CmbStavke()
                {
                    id = s.GradID,
                    opis = s.Naziv
                })
                .AsQueryable();
            return data.Take(100).ToList();
        }
        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
            List<Presjedanje> presjedanje = _dbContext.Presjedanje.Where(x => x.GradID == id).ToList();
            _dbContext.RemoveRange(presjedanje);
            _dbContext.SaveChanges();

            List<Let> let = _dbContext.Let.Where(x => x.PolazisteGradID == id || x.DestinacijaGradID==id).ToList();
            _dbContext.RemoveRange(let);
            _dbContext.SaveChanges();

            Grad grad = _dbContext.Grad.Find(id);

            if (grad == null)
                return BadRequest("pogresan ID");

            _dbContext.Remove(grad);

            _dbContext.SaveChanges();
            return Ok(grad);
        }

        [HttpGet]
        public List<GradGetAllVM> GetByAll()
        {
            var data = _dbContext.Grad
                .OrderBy(s => s.Naziv)
                .Select(s => new GradGetAllVM()
                {
                    id = s.GradID,
                    opis = s.Naziv,
                    drzava = s.Drzava.Naziv
                })
                .AsQueryable();
            return data.Take(100).ToList();
        }
    }
}

