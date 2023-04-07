using System;

namespace MilesAway.Controllers
{
    public class KartaGetAllVM
    {
        public int id { get; set; }
        public string vrijemepolaska { get; set; }
        public string vrijemedolaska { get; set; }
        public float Cijena { get; set; }
        public bool Aktivna { get; set; }
        public string Sjediste { get; set; }
        public int? TipKarteID { get; set; }
        public int? LetID { get; set; }
    }
}