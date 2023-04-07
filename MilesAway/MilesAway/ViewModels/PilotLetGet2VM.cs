using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilesAway.ViewModels
{
    public class PilotLetGet2VM
    {
        public int Id { get; set; }
        public int? PilotID { get; set; }
        public int? LetID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojDozvole { get; set; }
        public string SifraLeta { get; set; }
    }
}
