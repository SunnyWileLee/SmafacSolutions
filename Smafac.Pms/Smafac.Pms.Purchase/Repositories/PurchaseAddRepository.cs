using Smafac.Framework.Core.Repositories;
using Smafac.Pms.Purchase.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Pms.Purchase.Repositories
{
    class PurchaseAddRepository : EntityAddRepository<PurchaseContext, PurchaseEntity>, IPurchaseAddRepository
    {
        public PurchaseAddRepository(IPurchaseContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}
