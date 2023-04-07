using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilesAway.ViewModels
{
    public class TipKarteGetAllVM
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public float Cijena { get; set; }
        public bool Aktivan { get; internal set; }
    }
}
