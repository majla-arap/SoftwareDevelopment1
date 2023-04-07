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
    public class PopustController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public PopustController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        [HttpPost]
        public ActionResult<VrstaPopusta> Add([FromBody] PopustAddVM x)
        {
            if (!HttpContext.GetLoginInfo().isPermisijaMenadzer)
                return BadRequest("nije logiran");

            var popust = new VrstaPopusta
            {
                Naziv = x.naziv,
                Popust = x._Popust,
                Aktivan = x._Aktivan,
               
            };

            _dbContext.Add(popust);
            _dbContext.SaveChanges();
            return popust;
        }
        [HttpPost("{id}")]
        public ActionResult Update(int id, [FromBody] PopustAddVM x)
        {
            VrstaPopusta popust = _dbContext.VrstaPopust.Find(id);

            if (popust == null)
                return BadRequest("pogresan ID");

            popust.Naziv = x.naziv;
            popust.Popust = x._Popust;
            popust.Aktivan = x._Aktivan;

            _dbContext.SaveChanges();
            return Ok(popust);
        }

        [HttpGet]
        public List<PopustGetAllVM> GetAll(string name)
        {
            var data = _dbContext.VrstaPopust.Where(x => name == null || x.Naziv.StartsWith(name)).OrderByDescending(s => s.PopustID)
                .Select(s => new PopustGetAllVM
                {
                    id = s.PopustID,
                    naziv = s.Naziv,
                    _Aktivan = s.Aktivan,
                    _Popust = s.Popust,
                 })
                .AsQueryable();
            return data.Take(100).ToList();
        }

        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
            List<KupljenaKarta> kupljenaKarta = _dbContext.KupljenaKarta.Where(x => x.PopustID == id).ToList();
            _dbContext.RemoveRange(kupljenaKarta);
            _dbContext.SaveChanges();

            VrstaPopusta popust = _dbContext.VrstaPopust.Find(id);

            if (popust == null)
                return BadRequest("Pogresan ID");

            _dbContext.Remove(popust);
            _dbContext.SaveChanges();
            return Ok(popust);
        }
    } 
}
