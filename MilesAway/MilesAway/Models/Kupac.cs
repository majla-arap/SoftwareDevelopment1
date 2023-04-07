using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MilesAway.Models
{
    [Table("Kupac")]
    public class Kupac:Korisnik
    {
        public string ToString()
        {
            return Ime + " " + Prezime;
        }
    }
}
