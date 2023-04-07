using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilesAway.ViewModels
{
    public class PresjedanjeGetVM
    {
        public int ID { get; set; }
        public string Grad { get; set; }
        public string SifraLeta { get; set; }
        public DateTime VrijemeDolaska { get; set; }
        public DateTime VrijemePolaska { get; set; }
    }
}
