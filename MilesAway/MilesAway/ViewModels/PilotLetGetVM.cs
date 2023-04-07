using MilesAway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilesAway.ViewModels
{
    public class PilotLetGetVM
    {
        public int LetID { get; set; }
        public string SifraLeta { get; set; }
        public string Polaziste { get; set; }
        public string Destinacija { get; set; }
        public List<PilotLet> PilotLet { get; set; }
        public List<PilotLetGet2VM> PilotLetGet { get; set; }
        public List<Pilot> Piloti { get; set; }
    }
}

