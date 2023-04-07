using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MilesAway.Models
{
    public class VrstaPutanjeKarte
    {
        [Key]
        public int PutanjaID { get; set; }
        public string Naziv { get; set; }

    }
}
