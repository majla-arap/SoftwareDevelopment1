using Microsoft.AspNetCore.Mvc.Rendering;
using MilesAway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilesAway.ViewModels
{
    public class KartaAddVM
    {
        public float Cijena { get; set; }
        public bool Aktivna { get; set; }
        public string Sjediste { get; set; }
        public int? TipKarteID { get; set; }
        public int? LetID { get; set; }
        public Grad Polaziste { get; set; }
        public Grad Destinacija { get; set; }

    }
}
