using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MilesAway.Models
{
    public class VrstaPopusta
    {

        [Key]
        public int PopustID { get; set; }
        public string Naziv { get; set; }
        public float Popust { get; set; } //ovdje smo htjeli da ovaj popust oduzimamo od cijene karte, tako neka stoji onda
        public bool Aktivan { get; set; }
    }
}
