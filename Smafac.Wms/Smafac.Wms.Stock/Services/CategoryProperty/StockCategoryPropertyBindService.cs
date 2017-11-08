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
        public StockCategoryPropertyBindService(IStockCategoryPropertyBindRepository categoryPropertyBindRepository,
                                                IStockCategoryPropertySearchRepository categoryPropertySearchRepository,
                                                IEnumerable<IStockCategoryPropertyBindTrigger> categoryPropertyBindTriggers,
                                                IStockCategorySearchRepository categorySearchRepository,
                                                IStockPropertySearchRepository propertySearchRepository
                                                )
        {
            base.EntityAssociationBindRepository = categoryPropertyBindRepository;
            base.EntityAssociationSearchRepository = categoryPropertySearchRepository;
            base.CategoryAssociationBindTriggers = categoryPropertyBindTriggers;
            base.CategorySearchRepository = categorySearchRepository;
            base.AssociationSearchRepository = propertySearchRepository;
        }
    }
}
