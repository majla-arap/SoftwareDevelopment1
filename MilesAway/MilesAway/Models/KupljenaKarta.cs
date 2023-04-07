using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MilesAway.Models
{
    public class KupljenaKarta
    {
        [Key]
        public int KupljenaKartaID { get; set; }
        public DateTime DatumKupovine { get; set; }
        public bool IsAktivna { get; set; }
        public bool PostojiPopust { get; set; }
        [ForeignKey(nameof(Karta))]
        public int? KartaID { get; set; }
        public Karta Karta { get; set; }
        [ForeignKey(nameof(Kupac))]
        public int? KupacID { get; set; }
        public Kupac Kupac { get; set; }
        [ForeignKey(nameof(Popust))]
        public int? PopustID { get; set; }
        public VrstaPopusta Popust { get; set; }
        [ForeignKey(nameof(TipPutnika))]
        public int? TipPutnikaID { get; set; }
        public TipPutnika TipPutnika { get; set; }
        [ForeignKey(nameof(TipPrtljage))]
        public int? TipPrtljageID { get; set; }
        public TipPrtljage TipPrtljage { get; set; }
        public bool Povratna { get; set; }
        public DateTime DatumPolaska { get; set; }
        public DateTime? DatumPovratka { get; set; }
        public float Cijena { get; set; }
    }
}
