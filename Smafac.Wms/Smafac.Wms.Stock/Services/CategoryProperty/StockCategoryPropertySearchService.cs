using Smafac.Framework.Core.Services.CategoryProperty;
using Smafac.Wms.Stock.Applications.CategoryProperty;
using Smafac.Wms.Stock.Domain;
using Smafac.Wms.Stock.Domain.CategoryProperty;
using Smafac.Wms.Stock.Models;
using Smafac.Wms.Stock.Repositories.CategoryProperty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Stock.Services.CategoryProperty
{
    class StockCategoryPropertySearchService : CategoryPropertySearchService<StockCategoryEntity, StockPropertyEntity, StockPropertyModel>,
                                                IStockCategoryPropertySearchService
    {
        public StockCategoryPropertySearchService(IStockCategoryPropertySearchRepository goodsCategoryPropertySearchRepository,
            IStockCategoryPropertyProvider goodsCategoryPropertyProvider
            )
        {
            base.CategoryAssociationProvider = goodsCategoryPropertyProvider;
            base.EntityAssociationSearchRepository = goodsCategoryPropertySearchRepository;
        }
    }
}
