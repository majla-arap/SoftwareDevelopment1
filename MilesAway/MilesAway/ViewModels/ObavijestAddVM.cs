using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilesAway.ViewModels
{
    public class ObavijestAddVM
    {
        public string Naslov { get; set; }
        public string PodNaslov { get; set; }
        public string Opis { get; set; }
        public DateTime datum { get; set; }
        public int? ObavijestKategorijeID { get; set; }
    }
}
