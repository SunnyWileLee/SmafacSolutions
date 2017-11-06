using Smafac.Framework.Core.Repositories.CategoryProperty;
using Smafac.Framework.Core.Services.CategoryProperty;
using Smafac.Wms.Stock.Applications.CategoryProperty;
using Smafac.Wms.Stock.Domain;
using Smafac.Wms.Stock.Domain.CategoryProperty;
using Smafac.Wms.Stock.Repositories.Category;
using Smafac.Wms.Stock.Repositories.CategoryProperty;
using Smafac.Wms.Stock.Repositories.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Stock.Services.CategoryProperty
{
    class StockCategoryPropertyBindService : CategoryPropertyBindService<StockCategoryEntity, StockPropertyEntity>,
                                        IStockCategoryPropertyBindService
    {
        public StockCategoryPropertyBindService(IStockCategoryPropertyBindRepository goodsCategoryPropertyBindRepository,
                                                IStockCategoryPropertySearchRepository goodsCategoryPropertySearchRepository,
                                                IEnumerable<IStockCategoryPropertyBindTrigger> goodsCategoryPropertyBindTriggers,
                                                IStockCategorySearchRepository goodsCategorySearchRepository,
                                                IStockPropertySearchRepository goodsPropertySearchRepository
                                                )
        {
            base.EntityAssociationBindRepository = goodsCategoryPropertyBindRepository;
            base.EntityAssociationSearchRepository = goodsCategoryPropertySearchRepository;
            base.CategoryAssociationBindTriggers = goodsCategoryPropertyBindTriggers;
            base.CategorySearchRepository = goodsCategorySearchRepository;
            base.AssociationSearchRepository = goodsPropertySearchRepository;
        }
    }
}
