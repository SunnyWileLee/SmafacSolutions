using Smafac.Framework.Core.Domain.Property;
using Smafac.Pms.Purchase.Repositories.PropertyValue;

namespace Smafac.Pms.Purchase.Domain.Property
{
    class CustomerPropertyDeleteValueTrigger : PropertyDeleteValueTrigger<PurchasePropertyEntity, PurchasePropertyValueEntity>,
                                            IPurchasePropertyDeleteTrigger
    {
        public CustomerPropertyDeleteValueTrigger(IPurchasePropertyValueDeleteRepository goodsPropertyValueDeleteRepository)
        {
            base.PropertyValueDeleteRepository = goodsPropertyValueDeleteRepository;
        }
    }
}
