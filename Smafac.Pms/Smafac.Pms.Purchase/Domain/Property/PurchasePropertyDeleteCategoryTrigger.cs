using Smafac.Framework.Core.Domain.Property;
using Smafac.Pms.Purchase.Repositories.CategoryProperty;

namespace Smafac.Pms.Purchase.Domain.Property
{
    class CustomerPropertyDeleteCategoryTrigger : PropertyDeleteCategoryTrigger<PurchaseCategoryEntity, PurchasePropertyEntity, PurchaseCategoryPropertyEntity>,
        IPurchasePropertyDeleteTrigger
    {
        public CustomerPropertyDeleteCategoryTrigger(IPurchaseCategoryPropertyBindRepository goodsCategoryPropertyBindRepository)
        {
            base.CategoryPropertyBindRepository = goodsCategoryPropertyBindRepository;
        }
    }
}
