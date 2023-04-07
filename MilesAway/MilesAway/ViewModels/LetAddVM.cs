using MilesAway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilesAway.ViewModels
{
    public class LetAddVM
    {
        public string SifraLeta { get; set; }
        public int PolazisteGradID { get; set; }
        public int DestinacijaGradID { get; set; }
        public DateTime VrijemePolaska { get; set; }
        public DateTime VrijemeDolaska { get; set; }
        public float JednosmijernaCijena { get; set; }
        public float PovratnaCijena { get; set; }
    }
}
