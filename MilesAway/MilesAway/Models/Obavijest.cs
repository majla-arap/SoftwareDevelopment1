using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MilesAway.Models
{
    public class Obavijest
    {
        [Key]
        public int ObavijestID { get; set; }
        public string Naslov { get; set; }
        public string PodNaslov { get; set; }
        public string Opis { get; set; }
        public string Slika { get; set; }
        public byte[] Slika_ { get; set; }
        public DateTime DatumKreiranja { get; set; }
        [ForeignKey(nameof(ObavijestKategorija))]
        public int? ObavijestKategorijeID { get; set; }
        public ObavijestKategorije ObavijestKategorija { get; set; }
        [ForeignKey(nameof(Menadzer))]
        public int? MenadzerID { get; set; }
        public Menadzer Menadzer { get; set; }

    }
}
