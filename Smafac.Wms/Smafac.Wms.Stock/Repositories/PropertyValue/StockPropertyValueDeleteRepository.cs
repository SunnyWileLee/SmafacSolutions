using Smafac.Framework.Core.Repositories.PropertyValue;
using Smafac.Wms.Stock.Domain;

namespace Smafac.Wms.Stock.Repositories.PropertyValue
{
    class StockPropertyValueDeleteRepository : PropertyValueDeleteRepository<StockContext, StockPropertyValueEntity>,
                                                IStockPropertyValueDeleteRepository
    {

        public StockPropertyValueDeleteRepository(IStockContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}
