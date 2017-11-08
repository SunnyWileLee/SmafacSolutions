using Smafac.Framework.Core.Domain.EntityAssociationProviders;
using Smafac.Pms.Purchase.Models;
using Smafac.Pms.Purchase.Repositories.Category;
using Smafac.Pms.Purchase.Repositories.CategoryProperty;

namespace Smafac.Pms.Purchase.Domain.CategoryProperty
{
    class PurchaseCategoryPropertyProvider : CategoryPropertyProvider<PurchaseCategoryEntity, PurchasePropertyEntity, PurchasePropertyModel>,
                                            IPurchaseCategoryPropertyProvider
    {

        public PurchaseCategoryPropertyProvider(IPurchaseCategoryPropertySearchRepository categoryPropertySearchRepository,
                                            IPurchaseCategorySearchRepository categorySearchRepository)
        {
            base.CategorySearchRepository = categorySearchRepository;
            base.CategoryAssociationSearchRepository = categoryPropertySearchRepository;
        }
    }
}
