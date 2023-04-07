using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilesAway.Helper
{
    public class AutorizacijaAtributi:TypeFilterAttribute
    {
        public AutorizacijaAtributi(bool kupac, bool menadzer, bool admin)
           : base(typeof(MyAuthorizeImpl))
        {
            Arguments = new object[] { };
        }
    }
    public class MyAuthorizeImpl : IActionFilter
    {
        private readonly bool _kupac;
        private readonly bool _menadzer;
        private readonly bool _admin;

        public MyAuthorizeImpl(bool kupac, bool menadzer, bool admin)
        {
            _kupac = kupac;
            _menadzer = menadzer;
            _admin = admin;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {


        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (filterContext.HttpContext.GetLoginInfo().isLogiran)
            {
                filterContext.Result = new UnauthorizedResult();
                return;
            }

            KretanjePoSistemu.Save(filterContext.HttpContext);

            if (filterContext.HttpContext.GetLoginInfo().isPermisijaAdmin)
            {
                return;//ok - ima pravo pristupa
            }
            
            if (filterContext.HttpContext.GetLoginInfo().isPermisijaKupac && _kupac)
            {
                return;//ok - ima pravo pristupa
            }
            if (filterContext.HttpContext.GetLoginInfo().isPermisijaMenadzer && _menadzer)
            {
                return;//ok - ima pravo pristupa
            }
            //else nema pravo pristupa
            filterContext.Result = new UnauthorizedResult();
        }
    }
}
