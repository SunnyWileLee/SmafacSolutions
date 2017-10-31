using Smafac.Framework.Core.Repositories.Category;
using Smafac.Pms.Purchase.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Pms.Purchase.Repositories.Category
{
    class PurchaseCategorySearchRepository : CategorySearchRepository<PurchaseContext, PurchaseCategoryEntity>, IPurchaseCategorySearchRepository
    {
        public PurchaseCategorySearchRepository(IPurchaseContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}
