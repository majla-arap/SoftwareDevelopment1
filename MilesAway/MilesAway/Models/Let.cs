using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MilesAway.Models
{
    public class Let
    {
        [Key]
        public int LetID { get; set; }
        public string SifraLeta { get; set; }
        [ForeignKey(nameof(Polaziste))]
        public int? PolazisteGradID { get; set; }
        public Grad Polaziste { get; set; }
        [ForeignKey(nameof(Destinacija))]
        public int? DestinacijaGradID { get; set; }
        public Grad Destinacija { get; set; }
        public DateTime DatumVrijemePolaska { get; set; }
        public DateTime VrijemeDolaska { get; set; }
        public TimeSpan VrijemeTrajanja { get; set; }
        public virtual ICollection<PilotLet> Pilot { get; set; }
       public virtual ICollection<AvionLet> Avion { get; set; }
        public float JednosmijernaCijena { get; set; }
        public float PovratnaCijena { get; set; }
       
    }
}
