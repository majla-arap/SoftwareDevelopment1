using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MilesAway.Data;
using MilesAway.Models;
using MilesAway.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilesAwayHCI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RegistracijaController : Controller
    {

        public ApplicationDbContext _dbContext;
        public RegistracijaController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        [HttpPost]
        public Kupac Add([FromBody] RegistracijaVM x)
        {
            var novi = new Kupac
            {
                Ime = x.ime,
                Prezime = x.prezime,
                korisnickoIme = x.korisnickoIme,
                lozinka = x.lozinka,
                email = x.email,

            };

            _dbContext.Add(novi);
            _dbContext.SaveChanges();
            return novi;
        }
        [HttpGet]
        public List<Kupac> GetAll()
        {
            var data = _dbContext.Kupac
                .Select(s => new Kupac
                {

                    Ime = s.Ime,
                    Prezime = s.Prezime,
                    korisnickoIme = s.korisnickoIme,
                    lozinka = s.lozinka,
                    email = s.email,

                })
                .AsQueryable();
            return data.Take(100).ToList();
        }
    }
}
