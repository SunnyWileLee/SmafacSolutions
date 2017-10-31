using Smafac.Framework.Core.Repositories.Category;
using Smafac.Pms.Purchase.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Pms.Purchase.Repositories.Category
{
    class PurchaseCategoryDeleteRepository : CategoryDeleteRepository<PurchaseContext, PurchaseCategoryEntity>, IPurchaseCategoryDeleteRepository
    {
        public PurchaseCategoryDeleteRepository(IPurchaseContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}
