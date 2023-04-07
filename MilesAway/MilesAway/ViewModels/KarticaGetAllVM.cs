using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilesAway.ViewModels
{
    public class KarticaGetAllVM
    {
        public int Id { get; set; }
        public string brojKartice { get; set; }
        public DateTime datumIsteka { get; set; }
        public int verifikacijskiKod { get; set; }
        public string imeVlasnika { get; set; }
    }
}
