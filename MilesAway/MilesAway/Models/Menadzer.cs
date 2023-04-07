using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MilesAway.Models
{
    [Table("Menadzer")]
    public class Menadzer:Korisnik
    {

        public DateTime DatumZaposlenja { get; set; }
        public string Adresa { get; set; }
        public string BrojTelefona { get; set; }
        public string ToString()
        {
            return Ime + " " + Prezime;
        }
    }
}
