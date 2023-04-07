using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilesAway.ViewModels
{
    public class IzvjestajGetAllVM
    {
        public int id { get; set; }
        public string Sadrzaj { get; set; }
        public DateTime Datum { get; set; }
        public int MenadzerID { get; set; }
       
    }
}
