using MilesAway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilesAway.ViewModels
{
    public class AvionLetGetVM
    {
        public int LetID { get; set; }
        public string SifraLeta { get; set; }
        public string Polaziste { get; set; }
        public string Destinacija { get; set; }
        public List<AvionLet> AvionLet { get; set; }
        public List<AvionLetGet2VM> AvionLetGet { get; set; }

        public List<Avion> Avion { get; set; }

    }
}
