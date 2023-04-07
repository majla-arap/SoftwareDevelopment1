using MilesAway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilesAway.ViewModels
{
    public class ObavijestGetVM
    {
        public int ObavijestID { get; set; }
        public string Naslov { get; set; }
        public string PodNaslov { get; set; }
        public string Opis { get; set; }
        public string Slika_ { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public int? ObavijestKategorijeID { get; set; }
        public ObavijestKategorije ObavijestKategorija { get; set; }
       
        public int? MenadzerID { get; set; }
        public Menadzer Menadzer { get; set; }
    }
}
