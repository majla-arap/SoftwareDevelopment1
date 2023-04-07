using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MilesAway.Data;
using MilesAway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using AutoMapper.QueryableExtensions;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace MilesAway.Helper
{
    public static class MyAuthTokenExtension
    {
        public class LoginInformacije
        {
            public LoginInformacije(AutentifikacijaToken autentifikacijaToken)
            {
                this.autentifikacijaToken = autentifikacijaToken;
            }

            [JsonIgnore]
            public Korisnik korisnickiNalog => autentifikacijaToken?.korisnickiNalog;
            public AutentifikacijaToken autentifikacijaToken { get; set; }

            public bool isLogiran => korisnickiNalog != null;
            public bool isPermisijaMenadzer => isLogiran && (korisnickiNalog.menadzer != null || korisnickiNalog.isAdmin);
            public bool isPermisijaKupac => isLogiran && (korisnickiNalog.kupac != null || korisnickiNalog.isAdmin);
            public bool isPermisijaAdmin => isLogiran && korisnickiNalog.isAdmin;

        }
        public static LoginInformacije GetLoginInfo(this HttpContext httpContext)
        {
            var token = httpContext.GetAuthToken();

            return new LoginInformacije(token);
        }

        public static AutentifikacijaToken GetAuthToken(this HttpContext httpContext)
        {
            string token = httpContext.GetMyAuthToken();
            ApplicationDbContext db = httpContext.RequestServices.GetService<ApplicationDbContext>();

            AutentifikacijaToken korisnickiNalog = db.AutentifikacijaToken
                .Include(s => s.korisnickiNalog)
                .SingleOrDefault(x => token != null && x.vrijednost == token);

            return korisnickiNalog;
        }


        public static string GetMyAuthToken(this HttpContext httpContext)
        {
            string token = httpContext.Request.Headers["autentifikacija-token"];
            return token;
        }
    }
}
