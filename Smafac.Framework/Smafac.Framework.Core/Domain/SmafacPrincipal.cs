using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Domain
{
    public class SmafacPrincipal : IPrincipal
    {
        public IIdentity Identity
        {
            get
            {
                return new ClaimsIdentity();
            }
        }

        public bool IsInRole(string role)
        {
            return false;
        }

        public UserContext UserContext { get; set; }
    }
}
