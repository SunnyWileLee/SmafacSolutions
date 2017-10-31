using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Pms.Purchase.Models;
using Smafac.Framework.Core.Repositories;
using Smafac.Pms.Purchase.Domain;

namespace Smafac.Pms.Purchase.Repositories
{
    class PurchaseUpdateRepository : EntityUpdateRepository<PurchaseContext, PurchaseEntity>,
                                    IPurchaseUpdateRepository
    {
        public PurchaseUpdateRepository(IPurchaseContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }

        protected override void SetValue(PurchaseEntity entity, PurchaseEntity source)
        {
            entity.Name = source.Name;
            entity.Price = source.Price;
        }
    }
}
