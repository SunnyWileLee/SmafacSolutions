using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Models
{
    public class UserContext
    {
        public Guid SubscriberId { get; set; }
        public Guid UserId { get; set; }
        public static UserContext Current
        {
            get
            {
                var principal = System.Threading.Thread.CurrentPrincipal;
                return (principal as SmafacPrincipal).UserContext;
            }
        }
    }
}
