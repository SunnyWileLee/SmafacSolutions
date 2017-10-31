using Smafac.Framework.Core.Domain.Property;
using Smafac.Pms.Purchase.Repositories.CategoryProperty;

namespace Smafac.Pms.Purchase.Domain.Property
{
    class PurchasePropertyUsedByCategoryChecker : PropertyUsedByCategoryChecker<PurchaseCategoryEntity, PurchasePropertyEntity>,
                                                IPurchasePropertyUsedChecker
    {
        public PurchasePropertyUsedByCategoryChecker(IPurchaseCategoryPropertySearchRepository goodsategoryPropertySearchRepository)
        {
            base.CategoryPropertySearchRepository = goodsategoryPropertySearchRepository;
        }
    }
}
