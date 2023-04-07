using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MilesAway.Models
{
    public class Grad
    {
        [Key]
        public int GradID { get; set; }
        public string Naziv { get; set; }
        [ForeignKey(nameof(Drzava))]
        public int? DrzavaID { get; set; }
        public Drzava Drzava { get; set; }
    }
}
