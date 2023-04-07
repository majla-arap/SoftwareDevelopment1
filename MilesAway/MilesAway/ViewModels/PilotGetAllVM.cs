using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilesAway.ViewModels
{
    public class PilotGetAllVM
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public char Spol { get; set; }
        public string JMBG { get; set; }
        public DateTime DatumZaposlenja { get; set; }
        public string BrojDozvole { get; set; }
        public string Kontakt { get; set; }
        public string Adresa { get; set; }
    }
}
