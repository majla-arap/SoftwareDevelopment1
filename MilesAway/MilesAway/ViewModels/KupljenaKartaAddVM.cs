using MilesAway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilesAway.ViewModels
{
    public class KupljenaKartaAddVM
    {
        public DateTime _DatumKupovine { get; set; }
        public bool _IsAktivna { get; set; }
        public bool _PostojiPopust { get; set; }
        public int? _KartaID { get; set; }
        public int? TipPrtljageID { get; set; }
        public int ? TipPutnikaID { get; set; }
    }
}
