using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MilesAway.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilesAway.Data
{
     public class ApplicationDbContext : DbContext
    {
        public DbSet<Drzava> Drzava { get; set; }
        public DbSet<Aerodrom> Aerodrom { get; set; }
        public DbSet<Aviokompanija> Aviokompanija { get; set; }
        public DbSet<Avion> Avion { get; set; }
        public DbSet<AutentifikacijaToken> AutentifikacijaToken { get; set; }
        public DbSet<Grad> Grad { get; set; }
        public DbSet<Let> Let { get; set; }
        public DbSet<Pilot> Pilot { get; set; }
        public DbSet<Presjedanje> Presjedanje { get; set; }
        public DbSet<Izvjestaj> Izvjestaj { get; set; }
        public DbSet<Karta> Karta { get; set; }
        public DbSet<Kartica> Kartica { get; set; }
        public DbSet<Korisnik> Korisnik { get; set; }
        public DbSet<Kupac> Kupac { get; set; }
        public DbSet<KupljenaKarta> KupljenaKarta { get; set; }
        public DbSet<Menadzer> Menadzer { get; set; }
        public DbSet<Obavijest> Obavijest { get; set; }
        public DbSet<ObavijestKategorije> ObavijestKategorije { get; set; }
        public DbSet<TipKarte> TipKarte { get; set; }
        public DbSet<TipPutnika> TipPutnika { get; set; }
        public DbSet<TipPrtljage> TipPrtljage { get; set; }
        public DbSet<VrstaPopusta> VrstaPopust { get; set; }
        public DbSet<AerodromLet> AerodromLet { get; set; }
        public DbSet<AvionLet> AvionLet { get; set; }
        public DbSet<PilotLet> PilotLet { get; set; }
        public DbSet<VrstaPutanjeKarte> VrstaPutanjeKarte { get; set; }


        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }



}

