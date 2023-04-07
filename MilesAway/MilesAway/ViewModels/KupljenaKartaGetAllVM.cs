using MilesAway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilesAway.ViewModels
{
    public class KupljenaKartaGetAllVM
    {
        public int id { get; set; }
        public DateTime _DatumKupovine { get; set; }
        public bool _IsAktivna { get; set; }
        public bool _PostojiPopust { get; set; }
        public int? _KartaID { get; set; }
        public int? _KupacID { get; set; }
    }
}
