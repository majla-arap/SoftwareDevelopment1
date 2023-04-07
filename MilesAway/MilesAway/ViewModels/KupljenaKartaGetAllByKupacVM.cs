using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilesAway.ViewModels
{
    public class KupljenaKartaGetAllByKupacVM
    {
        public string DatumKupovine { get; set; }
        //public bool IsAktivna { get; set; }
        //public bool PostojiPopust { get; set; }
        public string SifraLeta { get; set; }
        public string Polaziste { get; set; }
        public string Destinacija { get; set; }
        public float Cijena { get; set; }
        public string Sjediste { get; set; }
        public string TipKarte { get; set; }
        public string DatumPolaska { get; set; }
        public DateTime? DatumPovratka { get; set; } //skontati drugi nacin
        public string TipPrtljage { get; set; }
        public string TipPutnika { get; set; }
        public string Popust { get; set; }
    }
}
