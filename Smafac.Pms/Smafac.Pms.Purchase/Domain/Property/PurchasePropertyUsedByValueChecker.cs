using Smafac.Framework.Core.Domain.Property;
using Smafac.Pms.Purchase.Models;
using Smafac.Pms.Purchase.Repositories.PropertyValue;

namespace Smafac.Pms.Purchase.Domain.Property
{
    class PurchasePropertyUsedByValueChecker : PropertyUsedByValueChecker<PurchasePropertyEntity, PurchasePropertyValueModel>,
                                                IPurchasePropertyUsedChecker
    {
        public PurchasePropertyUsedByValueChecker(IPurchasePropertyValueSearchRepository goodsPropertyValueSearchRepository)
        {
            base.PropertyValueSearchRepository = goodsPropertyValueSearchRepository;
        }
    }
}
