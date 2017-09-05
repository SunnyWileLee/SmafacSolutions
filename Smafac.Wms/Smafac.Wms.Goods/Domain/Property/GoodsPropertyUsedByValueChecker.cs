using Smafac.Framework.Core.Domain.Property;
using Smafac.Wms.Goods.Models;
using Smafac.Wms.Goods.Repositories.PropertyValue;

namespace Smafac.Wms.Goods.Domain.Property
{
    class GoodsPropertyUsedByValueChecker : PropertyUsedByValueChecker<GoodsPropertyEntity, GoodsPropertyValueModel>,
                                                IGoodsPropertyUsedChecker
    {
        public GoodsPropertyUsedByValueChecker(IGoodsPropertyValueSearchRepository customerFinancePropertyValueSearchRepository)
        {
            base.PropertyValueSearchRepository = customerFinancePropertyValueSearchRepository;
        }
    }
}
