using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilesAway.ViewModels
{
    public class PresjedanjeAddVM
    {
        
        public int? GradID { get; set; }
        public int? LetID { get; set; }
        public DateTime VrijemeDolaska { get; set; }
        public DateTime VrijemePolaska { get; set; }
    }
}
