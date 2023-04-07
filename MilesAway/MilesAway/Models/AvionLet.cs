using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MilesAway.Models
{
    public class AvionLet
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Avion))]
        public int? AvionID { get; set; }
        public Avion Avion { get; set; }
        [ForeignKey(nameof(Let))]
        public int? LetID { get; set; }
        public Let Let { get; set; }
    }
}