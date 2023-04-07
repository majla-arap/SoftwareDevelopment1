using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilesAway.ViewModels
{
    public class RacunGetVM
    {
        public string DatumKupovine { get; set; }
        public string Ime { get; set; }
        public string Polaziste { get; set; }
        public string Destinacija { get; set; }
        public string DatumPolaska { get; set; }
        public string DatumPovratka { get; set; }
        public string TipKarte { get; set; }
        public float CijenaKarte { get; set; }
        public string TipPrtljage { get; set; }
        public float CijenaPrtljage { get; set; }
        public string TipPutnika { get; set; }
        public float DodatakTipPutnika { get; set; }
        public float UkupnaCijena { get; set; }
        public string Povratna { get; set; }
        public bool PovratnaBool { get; set; }

    }
}
