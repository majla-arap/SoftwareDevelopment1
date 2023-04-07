﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MilesAway.Models
{
    public class LogKretanjePoSistemu
    {
        [Key]
        public int id { get; set; }
        [ForeignKey(nameof(korisnik))]
        public string korisnikID { get; set; }
        public Korisnik korisnik { get; set; }
        public string queryPath { get; set; }
        public string postData { get; set; }
        public DateTime vrijeme { get; set; }
        public string ipAdresa { get; set; }
        public string exceptionMessage { get; set; }
        public bool isException { get; set; }
    }
}
