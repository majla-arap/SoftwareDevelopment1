using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MilesAway.Models
{
    public class Pilot
    {
        [Key]
        public int PilotID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public char Spol { get; set; }
        public string JMBG { get; set; }
        public DateTime DatumZaposlenja { get; set; }
        public string BrojDozvole { get; set; }
        public string Kontakt { get; set; }
        public string Adresa { get; set; }
        public string ToString()
        {
            return Ime + " " + Prezime;
        }
    }
}
