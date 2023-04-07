using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilesAway.ViewModels
{
    public class PopustGetAllVM
    {
        public int id { get; set; }

        public string naziv { get; set; }
        public float _Popust { get; set; }
        public bool _Aktivan { get; set; }
    }
}
