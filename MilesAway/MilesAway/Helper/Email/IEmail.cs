using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilesAway.Helper.Email
{
    public interface IEmail
    {
        Task Send(string subject, string body, string toAddress, string name);
    }
}
