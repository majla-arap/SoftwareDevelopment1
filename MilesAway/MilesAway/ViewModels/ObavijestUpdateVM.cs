using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace MilesAway.ViewModels
{
    public class ObavijestUpdateVM
    {
        public string Naslov { get; set; }
        public string PodNaslov { get; set; }
        public string Opis { get; set; }
        public int? ObavijestKategorijeID { get; set; }
    }
}
