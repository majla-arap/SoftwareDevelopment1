using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MilesAway.Models
{
    public class Izvjestaj
    {
        [Key]
        public int IzvjestajID { get; set; }
        public string Sadrzaj { get; set; }
        public DateTime Datum { get; set; }
        [ForeignKey(nameof(Menadzer))]
        public int? MenadzerID { get; set; }
        public Menadzer Menadzer { get; set; }
    
    }
}
