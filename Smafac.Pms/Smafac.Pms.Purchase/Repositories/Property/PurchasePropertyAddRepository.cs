using Smafac.Framework.Core.Repositories.Property;
using Smafac.Pms.Purchase.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Pms.Purchase.Repositories.Property
{
    class PurchasePropertyAddRepository : PropertyAddRepository<PurchaseContext, PurchasePropertyEntity>, IPurchasePropertyAddRepository
    {
        public PurchasePropertyAddRepository(IPurchaseContextProvider contextProvider)
        {
            base.ContextProvider  = contextProvider;
        }
    }
}
