using Smafac.Framework.Core.Domain.EntityAssociationProviders;
using Smafac.Wms.Stock.Models;
using Smafac.Wms.Stock.Repositories.Category;
using Smafac.Wms.Stock.Repositories.CategoryProperty;

namespace Smafac.Wms.Stock.Domain.CategoryProperty
{
    class StockCategoryPropertyProvider : CategoryPropertyProvider<StockCategoryEntity, StockPropertyEntity, StockPropertyModel>,
                                            IStockCategoryPropertyProvider
    {

        public StockCategoryPropertyProvider(IStockCategoryPropertySearchRepository categoryPropertySearchRepository,
                                            IStockCategorySearchRepository categorySearchRepository)
        {
            base.CategorySearchRepository = categorySearchRepository;
            base.CategoryAssociationSearchRepository = categoryPropertySearchRepository;
        }
    }
}
