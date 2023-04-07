using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilesAway.ViewModels
{
    public class AvionAddVM
    {
        public string brojRegistracije { get; set; }
        public int brojMaxSjedista { get; set; }
        public DateTime datumZadnjegServisa { get; set; }
        public int brojSjedistaPrveKlase { get; set; }
        public int brojSjedistaBusiness { get; set; }
        public int Aviokompanija_ID { get; set; }
    }
}
