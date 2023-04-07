using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MilesAway.Models
{
    public class Presjedanje
    {
        [Key]
        public int PresjedanjeID { get; set; }
        public DateTime VrijemeDolaska { get; set; }
        public DateTime VrijemePolaska { get; set; }
        [ForeignKey(nameof(MjestoPresjedanja))]
        public int? GradID { get; set; }
        public Grad MjestoPresjedanja { get; set; }
        [ForeignKey(nameof(Let))]
        public int? LetID { get; set; }
        public Let Let { get; set; }
        
    }
}
