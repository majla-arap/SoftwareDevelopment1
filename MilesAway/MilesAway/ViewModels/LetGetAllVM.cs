using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilesAway.ViewModels
{
    public class LetGetAllVM
    {
        public int ID { get; set; }
        public string SifraLeta { get; set; }
        public string Polaziste { get; set; }
        public string Destinacija { get; set; }
        public DateTime DatumVrijemePolaska { get; set; }
        public DateTime VrijemeDolaska { get; set; }
        public float JednosmijernaCijena { get; set; }
        public float PovratnaCijena { get; set; }
    }
}
