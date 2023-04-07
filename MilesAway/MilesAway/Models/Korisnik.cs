using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MilesAway.Models
{
    public abstract class Korisnik
    {
        [Key]   
        public int KorisnikID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string korisnickoIme { get; set; }
        public string email { get; set; }

        [JsonIgnore]
        public string lozinka { get; set; }
        public string slika_korisnika { get; set; }
        [JsonIgnore]
        public Kupac kupac => this as Kupac;

        [JsonIgnore]
        public Menadzer menadzer => this as Menadzer;
        public bool isMenadzer => menadzer != null;
        public bool isKupac => kupac != null;
        public bool isAdmin { get; set; }

    }
}
