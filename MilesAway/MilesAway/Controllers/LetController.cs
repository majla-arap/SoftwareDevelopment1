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
    public class LetController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public LetController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpPost]
        public ActionResult<Let> Add([FromBody] LetAddVM x)
        {
            var noviLet = new Let
            {
                SifraLeta=x.SifraLeta,
                PolazisteGradID = x.PolazisteGradID,
                DestinacijaGradID=x.DestinacijaGradID,
                DatumVrijemePolaska=x.VrijemePolaska,
                VrijemeDolaska=x.VrijemeDolaska,
                JednosmijernaCijena=x.JednosmijernaCijena,
                PovratnaCijena=x.PovratnaCijena
            };

            _dbContext.Add(noviLet);
            _dbContext.SaveChanges();
            return noviLet;
        }

        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
            List<AvionLet> avionLet = _dbContext.AvionLet.Where(x => x.LetID == id).ToList();
            _dbContext.RemoveRange(avionLet);
            _dbContext.SaveChanges();

            List<Presjedanje> presjedanje = _dbContext.Presjedanje.Where(x => x.LetID == id).ToList();
            _dbContext.RemoveRange(presjedanje);
            _dbContext.SaveChanges();

            List<PilotLet> pilotLet = _dbContext.PilotLet.Where(x => x.LetID == id).ToList();
            _dbContext.RemoveRange(pilotLet);
            _dbContext.SaveChanges();

            List<AerodromLet> aerodromLet = _dbContext.AerodromLet.Where(x => x.LetID == id).ToList();
            _dbContext.RemoveRange(aerodromLet);
            _dbContext.SaveChanges();

            List<KupljenaKarta> kkarta = _dbContext.KupljenaKarta.Where(x => x.Karta.LetID == id).ToList();
            _dbContext.RemoveRange(kkarta);
            _dbContext.SaveChanges();

            List<Karta> karta= _dbContext.Karta.Where(x => x.LetID == id).ToList();
            _dbContext.RemoveRange(karta);
            _dbContext.SaveChanges();


            Let let = _dbContext.Let.Find(id);

            if (let == null)
                return BadRequest("Pogresan ID");

            _dbContext.Remove(let);
            _dbContext.SaveChanges();
            return Ok(let);
            
        }

        [HttpPost("{id}")]
        public ActionResult Update(int id, [FromBody] LetAddVM x)
        {
            Let let = _dbContext.Let.Find(id);
            //Let let = _dbContext.Let.Include(s => s.Polaziste).FirstOrDefault(s => s.LetID==id);
           
            if (let == null)
                return BadRequest("Pogresan ID");

            let.SifraLeta = x.SifraLeta;
            let.PolazisteGradID = x.PolazisteGradID;
            let.DestinacijaGradID = x.DestinacijaGradID;
            let.DatumVrijemePolaska = x.VrijemePolaska;
            let.VrijemeDolaska = x.VrijemeDolaska;
            let.JednosmijernaCijena = x.JednosmijernaCijena;
            let.PovratnaCijena = x.PovratnaCijena;

            _dbContext.SaveChanges();
            return Ok(let);
        }

        [HttpGet]
        public ActionResult<Let> GetByID(int id)
        {
            var result = _dbContext.Let.Include(x => x.Polaziste).Include(x => x.Destinacija).FirstOrDefault(x => x.LetID == id);
            return result;
        }

        [HttpGet]
        public ActionResult<List<LetGetAllVM>> GetAll(string filter)
        {
            var data = _dbContext.Let.OrderBy(x=>x.SifraLeta).Where(x => filter == null || x.SifraLeta.ToLower().StartsWith(filter.ToLower())
                                                                || x.Polaziste.Naziv.ToLower().StartsWith(filter.ToLower())
                                                                || x.Destinacija.Naziv.ToLower().StartsWith(filter.ToLower())
                                                                || x.VrijemeDolaska.ToString().StartsWith(filter.ToLower())
                                                                || x.DatumVrijemePolaska.ToString().StartsWith(filter.ToLower()))
                .Select(s => new LetGetAllVM
                {
                    ID=s.LetID,
                    SifraLeta = s.SifraLeta,
                    Polaziste = s.Polaziste.Naziv,
                    Destinacija = s.Destinacija.Naziv,
                    DatumVrijemePolaska = s.DatumVrijemePolaska,
                    VrijemeDolaska = s.VrijemeDolaska,
                    JednosmijernaCijena=s.JednosmijernaCijena,
                    PovratnaCijena=s.PovratnaCijena
                })
                .AsQueryable();
            return data.Take(100).ToList();
        }
        

        [HttpGet]
        public ActionResult<PagedList<LetGetAllVM>> GetAllPaged(string filter, int page_number = 1)
        {
            var data = _dbContext.Let.Where(x => filter == null || x.SifraLeta.ToLower().StartsWith(filter.ToLower()))
                .Select(s => new LetGetAllVM
                {
                    ID = s.LetID,
                    SifraLeta = s.SifraLeta,
                    Polaziste = s.Polaziste.Naziv,
                    Destinacija = s.Destinacija.Naziv,
                    DatumVrijemePolaska = s.DatumVrijemePolaska,
                    VrijemeDolaska = s.VrijemeDolaska,
                    JednosmijernaCijena = s.JednosmijernaCijena,
                    PovratnaCijena = s.PovratnaCijena
                })
                .AsQueryable();
            return PagedList<LetGetAllVM>.Create(data, page_number, 50);
        }

        /*[HttpGet]
        public ActionResult<List<LetGetAllVM>> GetAllPovratneKarte(string polaziste, string destinacija, DateTime polazak, DateTime dolazak)
        {

            if (polaziste == null || destinacija == null || polazak == null)
                return null;
            var data = _dbContext.Let.Include(x => x.Destinacija).Include(x => x.Polaziste)
                .Where(x => ((x.Polaziste.Naziv.ToLower().StartsWith(polaziste.ToLower())
                && x.Destinacija.Naziv.ToLower().StartsWith(destinacija.ToLower())) ||
                (x.Destinacija.Naziv.ToLower().StartsWith(polaziste.ToLower())
                && x.Polaziste.Naziv.ToLower().StartsWith(destinacija.ToLower())))
            && x.DatumVrijemePolaska.Day == polazak.Day
            && x.DatumVrijemePolaska.Month == polazak.Month
            && x.DatumVrijemePolaska.Year == polazak.Year
            && x.VrijemeDolaska.Day == dolazak.Day
            && x.VrijemeDolaska.Month == dolazak.Month
            && x.VrijemeDolaska.Year == dolazak.Year
            ).Select(s => new LetGetAllVM
            {
                ID = s.LetID,
                SifraLeta = s.SifraLeta,
                Polaziste = s.Polaziste.Naziv,
                Destinacija = s.Destinacija.Naziv,
                DatumVrijemePolaska = s.DatumVrijemePolaska,
                VrijemeDolaska = s.VrijemeDolaska,
                JednosmijernaCijena = s.JednosmijernaCijena,
                PovratnaCijena = s.PovratnaCijena
            })
                .AsQueryable();
            return data?.Take(100).ToList();
        }*/

        [HttpGet]
        public ActionResult<List<LetGetAllVM>> GetAllKarte(string polaziste, string destinacija, DateTime polazak)
        {

            if (polaziste == null || destinacija == null )
                return null;
            var data = _dbContext.Let.Include(x => x.Destinacija).Include(x => x.Polaziste)
                .Where(x => x.Polaziste.Naziv.ToLower().StartsWith(polaziste.ToLower())
                && x.Destinacija.Naziv.ToLower().StartsWith(destinacija.ToLower())
            && x.DatumVrijemePolaska.Day == polazak.Day
            && x.DatumVrijemePolaska.Month == polazak.Month
            && x.DatumVrijemePolaska.Year == polazak.Year
            ).Select(s => new LetGetAllVM
            {
                ID = s.LetID,
                SifraLeta = s.SifraLeta,
                Polaziste = s.Polaziste.Naziv,
                Destinacija = s.Destinacija.Naziv,
                DatumVrijemePolaska = s.DatumVrijemePolaska,
                VrijemeDolaska = s.VrijemeDolaska,
                JednosmijernaCijena = s.JednosmijernaCijena,
                PovratnaCijena = s.PovratnaCijena
            })
                .AsQueryable();
            return data?.Take(100).ToList();
        }
    }
}
