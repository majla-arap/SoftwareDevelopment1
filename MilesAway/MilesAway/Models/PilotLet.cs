using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MilesAway.Models
{
    public class PilotLet
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Pilot))]
        public int? PilotID { get; set; }
        public Pilot Pilot { get; set; }
        [ForeignKey(nameof(Let))]
        public int? LetID { get; set; }
        public Let Let { get; set; }
        
    }
}
