using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MilesAway.Models
{
    public class Kartica
    {
        [Key]
        public int KarticaID { get; set; }
        public string BrojKartice { get; set; }
        public DateTime DatumIsteka { get; set; }
        public int VerifikacijskiKod { get; set; }
        [ForeignKey(nameof(Kupac))]
        public int? KupacID { get; set; }
        public Kupac Kupac { get; set; }
        public string imeVlasnika { get; set; }

    }
}
