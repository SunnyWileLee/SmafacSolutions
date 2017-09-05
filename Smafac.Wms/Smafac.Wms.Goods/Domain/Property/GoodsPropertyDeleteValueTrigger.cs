using Smafac.Framework.Core.Domain.Property;
using Smafac.Wms.Goods.Repositories.PropertyValue;

namespace Smafac.Wms.Goods.Domain.Property
{
    class CustomerPropertyDeleteValueTrigger : PropertyDeleteValueTrigger<GoodsPropertyEntity, GoodsPropertyValueEntity>,
                                            IGoodsPropertyDeleteTrigger
    {
        public CustomerPropertyDeleteValueTrigger(IGoodsPropertyValueDeleteRepository goodsPropertyValueDeleteRepository)
        {
            base.PropertyValueDeleteRepository = goodsPropertyValueDeleteRepository;
        }
    }
}
