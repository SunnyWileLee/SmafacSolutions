using Smafac.Framework.Core.Domain.Property;
using Smafac.Wms.Stock.Models;
using Smafac.Wms.Stock.Repositories.PropertyValue;

namespace Smafac.Wms.Stock.Domain.Property
{
    class StockPropertyUsedByValueChecker : PropertyUsedByValueChecker<StockPropertyEntity, StockPropertyValueModel>,
                                                IStockPropertyUsedChecker
    {
        public StockPropertyUsedByValueChecker(IStockPropertyValueSearchRepository goodsPropertyValueSearchRepository)
        {
            base.PropertyValueSearchRepository = goodsPropertyValueSearchRepository;
        }
    }
}
