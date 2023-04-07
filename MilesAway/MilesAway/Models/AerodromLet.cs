using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MilesAway.Models
{
    public class AerodromLet
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Let))]
        public int? LetID { get; set; }
        public Let Let { get; set; }
        [ForeignKey(nameof(Aerodrom1))]
        public int? AerodromID { get; set; }
        public Aerodrom Aerodrom1 { get; set; }
        [ForeignKey(nameof(Aerodrom2))]
        public int? AerodromID_ID { get; set; }
        public Aerodrom Aerodrom2{ get; set; }
    }
}
