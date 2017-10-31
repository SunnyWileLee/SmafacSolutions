using Smafac.Framework.Core.Repositories.Property;
using Smafac.Pms.Purchase.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Pms.Purchase.Repositories.Property
{
    class PurchasePropertyDeleteRepository : PropertyDeleteRepository<PurchaseContext, PurchasePropertyEntity>, IPurchasePropertyDeleteRepository
    {
        public PurchasePropertyDeleteRepository(IPurchaseContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}
