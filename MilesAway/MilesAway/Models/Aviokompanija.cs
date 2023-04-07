using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MilesAway.Models
{
    public class Aviokompanija
    {
        [Key]
        public int AviokompanijaID { get; set; }
        public string Naziv { get; set; }
    }
}
