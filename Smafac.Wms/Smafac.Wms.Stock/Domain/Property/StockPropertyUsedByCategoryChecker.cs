using Smafac.Framework.Core.Domain.Property;
using Smafac.Wms.Stock.Repositories.CategoryProperty;

namespace Smafac.Wms.Stock.Domain.Property
{
    class StockPropertyUsedByCategoryChecker : PropertyUsedByCategoryChecker<StockCategoryEntity, StockPropertyEntity>,
                                                IStockPropertyUsedChecker
    {
        public StockPropertyUsedByCategoryChecker(IStockCategoryPropertySearchRepository goodsategoryPropertySearchRepository)
        {
            base.CategoryPropertySearchRepository = goodsategoryPropertySearchRepository;
        }
    }
}
