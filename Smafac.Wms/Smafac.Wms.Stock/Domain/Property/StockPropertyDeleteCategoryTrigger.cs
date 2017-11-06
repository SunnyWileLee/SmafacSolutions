using Smafac.Framework.Core.Domain.Property;
using Smafac.Wms.Stock.Repositories.CategoryProperty;

namespace Smafac.Wms.Stock.Domain.Property
{
    class CustomerPropertyDeleteCategoryTrigger : PropertyDeleteCategoryTrigger<StockCategoryEntity, StockPropertyEntity, StockCategoryPropertyEntity>,
        IStockPropertyDeleteTrigger
    {
        public CustomerPropertyDeleteCategoryTrigger(IStockCategoryPropertyBindRepository goodsCategoryPropertyBindRepository)
        {
            base.CategoryPropertyBindRepository = goodsCategoryPropertyBindRepository;
        }
    }
}
