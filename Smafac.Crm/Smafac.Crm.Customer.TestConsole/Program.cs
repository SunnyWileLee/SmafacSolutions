using Smafac.Framework.Core.Domain;
using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var accountId = Guid.Parse("de6acd65-8e0c-453c-b205-b0924545b13c");
            var userId = Guid.Parse("42bea74f-5a57-4ffa-9d9e-ed69532920ff");
            SmafacPrincipal principal = new SmafacPrincipal
            {
                UserContext = new UserContext
                {
                    AccountId = accountId,
                    UserId = userId
                }
            };
            System.Threading.Thread.CurrentPrincipal = principal;

        }
    }
}
