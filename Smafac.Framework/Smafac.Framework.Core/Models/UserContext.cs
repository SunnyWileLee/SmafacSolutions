using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

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
                var name = Thread.CurrentPrincipal.Identity.Name;
                var ids = name.Split(';');
                return new UserContext
                {
                    SubscriberId = Guid.Parse(ids[0]),
                    UserId = Guid.Parse(ids[1])
                };
            }
        }
    }
}
