using MilesAway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilesAway.ViewModels
{
    public class AerodromLetGetVM
    {
        public int LetID { get; set; }
        public string SifraLeta { get; set; }
        public string Polaziste { get; set; }
        public string Destinacija { get; set; }
        public List<AerodromLet> AerodromLet { get; set; }
        public List<Aerodrom> AerodromPolaska { get; set; }
        public List<Aerodrom> AerodromDestinacije { get; set; }

    }
}
