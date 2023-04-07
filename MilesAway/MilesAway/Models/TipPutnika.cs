using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MilesAway.Models
{
    public class TipPutnika
    {
        [Key]
        public int TipID { get; set; }
        public string Naziv { get; set; }
        public float Cijena { get; set; }
    }
}
