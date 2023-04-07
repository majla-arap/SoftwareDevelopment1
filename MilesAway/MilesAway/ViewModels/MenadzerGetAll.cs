using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilesAway.ViewModels
{
    public class MenadzerGetAll
    {
        public int id { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public DateTime datumZaposlenja { get; set; }
        public string adresa { get; set; }
        public string brojTelefona { get; set; }
    }
}
