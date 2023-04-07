using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MilesAway.Models
{
    public class Aerodrom
    {
        [Key]
        public int AerodromID { get; set; }
        public string Naziv { get; set; }
        [ForeignKey(nameof(Grad))]
        public int? GradID { get; set; }
        public Grad Grad { get; set; }


    }
}
