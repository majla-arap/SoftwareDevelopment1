using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MilesAway.Models
{
    public class Karta
    {
        [Key]
        public int KartaID { get; set; }
        public float Cijena { get; set; }
        public bool Aktivna { get; set; }
        public string Sjediste { get; set; }
        [ForeignKey(nameof(TipKarte))]
        public int? TipKarteID { get; set; }
        public TipKarte TipKarte { get; set; }
        [ForeignKey(nameof(Let))]
        public int? LetID { get; set; }
        public Let Let { get; set; }
        [ForeignKey(nameof(Putanja))]
        public int? PutanjaID { get; set; }
        public VrstaPutanjeKarte Putanja { get; set; }
        

    }
}
