using Smafac.Framework.Core.Domain.Property;
using Smafac.Wms.Stock.Repositories.PropertyValue;

namespace Smafac.Wms.Stock.Domain.Property
{
    class CustomerPropertyDeleteValueTrigger : PropertyDeleteValueTrigger<StockPropertyEntity, StockPropertyValueEntity>,
                                            IStockPropertyDeleteTrigger
    {
        public CustomerPropertyDeleteValueTrigger(IStockPropertyValueDeleteRepository propertyValueDeleteRepository)
        {
            base.PropertyValueDeleteRepository = propertyValueDeleteRepository;
        }
    }
}
