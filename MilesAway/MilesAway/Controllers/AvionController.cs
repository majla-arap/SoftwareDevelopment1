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
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class AvionController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public AvionController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
      
        [HttpPost]
        public ActionResult<Avion> Add([FromBody] AvionAddVM x)
        {
            if (!HttpContext.GetLoginInfo().isPermisijaMenadzer)
                return BadRequest("nije logiran");

            var newAvion = new Avion
            {
                BrojRegistracije = x.brojRegistracije,
                BrojMaxSjedista = x.brojMaxSjedista,
                DatumZadnjegServisa = x.datumZadnjegServisa,
                BrojSjedistaBusiness=x.brojSjedistaBusiness,
                BrojSjedistaPrveKlase=x.brojSjedistaPrveKlase,
                AviokompanijaID=x.Aviokompanija_ID
            };

            _dbContext.Add(newAvion);
            _dbContext.SaveChanges();
            return newAvion;
        }

        [HttpPost("{id}")]
        public ActionResult Update(int id, [FromBody] AvionAddVM x)
        {
            Avion avion = _dbContext.Avion.Include(s=>s.Aviokompanija).FirstOrDefault(s=>s.AvionID==id);
 
            if (avion == null)
                return BadRequest("Pogresan ID");
            
            avion.BrojRegistracije = x.brojRegistracije;
            avion.BrojMaxSjedista = x.brojMaxSjedista;
            avion.DatumZadnjegServisa = x.datumZadnjegServisa;
            avion.BrojSjedistaBusiness = x.brojSjedistaBusiness;
            avion.BrojSjedistaPrveKlase = x.brojSjedistaPrveKlase;
            avion.AviokompanijaID = x.Aviokompanija_ID;

            _dbContext.SaveChanges();
            return Ok(avion);
        }

        [HttpGet]
        public List<AvionGetAllVM> GetByAviokompanija(string aviokomp_id)
        {
            var data = _dbContext.Avion.Where(x => aviokomp_id == null || x.Aviokompanija.Naziv.ToLower().StartsWith(aviokomp_id.ToLower()))
                .OrderBy(s => s.BrojRegistracije)
                .Select(s => new AvionGetAllVM()
                {

                    Id = s.AvionID,
                    

                    opis = s.Aviokompanija.Naziv,                   
                    brojRegistracije = s.BrojRegistracije,
                    brojMaxSjedista = s.BrojMaxSjedista,
                    brojSjedistaBusiness = s.BrojSjedistaBusiness,
                    brojSjedistaPrveKlase = s.BrojSjedistaPrveKlase,
                    datumZadnjegServisa = s.DatumZadnjegServisa,
                    Aviokompanija_ID = s.AviokompanijaID.Value

                })
                .AsQueryable();
            return data.Take(100).ToList();
        }

        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
            List<AvionLet> avlet = _dbContext.AvionLet.Where(x => x.Avion.AvionID== id).ToList();
            _dbContext.RemoveRange(avlet);
            _dbContext.SaveChanges();

            Avion Avion = _dbContext.Avion.Find(id);

            if (Avion == null || id == 1)
                return BadRequest("pogresan ID");

            _dbContext.Remove(Avion);

            _dbContext.SaveChanges();
            return Ok(Avion);
        }

        [HttpGet]
        public List<AvionGetAllVM> GetAll()
        {
            var data = _dbContext.Avion
                .OrderBy(x=>x.AvionID)
                .Select(s => new AvionGetAllVM
                {
                    Id = s.AvionID,
                    opis = s.Aviokompanija.Naziv,
                    brojRegistracije = s.BrojRegistracije,
                    brojMaxSjedista = s.BrojMaxSjedista,
                    brojSjedistaBusiness = s.BrojSjedistaBusiness,
                    brojSjedistaPrveKlase = s.BrojSjedistaPrveKlase,
                    datumZadnjegServisa = s.DatumZadnjegServisa,
                    Aviokompanija_ID = s.AviokompanijaID.Value

                })
                .AsQueryable();
            return data.Take(100).ToList();
        }
    }
}
