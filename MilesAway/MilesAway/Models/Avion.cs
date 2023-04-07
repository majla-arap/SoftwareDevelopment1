using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MilesAway.Models
{
    public class Avion
    {
        [Key]
        public int AvionID { get; set; }
        public string BrojRegistracije { get; set; }
        public int BrojMaxSjedista { get; set; }
        public DateTime DatumZadnjegServisa { get; set; }
        public int BrojSjedistaPrveKlase { get; set; }
        public int BrojSjedistaBusiness { get; set; }
        [ForeignKey(nameof(Aviokompanija))]
        public int? AviokompanijaID { get; set; }
        public Aviokompanija Aviokompanija { get; set; }


    }
}
