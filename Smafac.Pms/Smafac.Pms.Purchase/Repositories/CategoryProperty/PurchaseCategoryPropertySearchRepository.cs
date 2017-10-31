using Smafac.Framework.Core.Repositories.CategoryProperty;
using Smafac.Pms.Purchase.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Pms.Purchase.Repositories.CategoryProperty
{
    class PurchaseCategoryPropertySearchRepository : CategoryPropertySearchRepository<PurchaseContext, PurchaseCategoryEntity, PurchasePropertyEntity, PurchaseCategoryPropertyEntity>,
                                                  IPurchaseCategoryPropertySearchRepository
    {
        public PurchaseCategoryPropertySearchRepository(IPurchaseContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}
