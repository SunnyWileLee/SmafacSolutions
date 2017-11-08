using Smafac.Wms.Stock.Applications.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Wms.Stock.Models;
using Smafac.Framework.Core.Services.Category;
using Smafac.Wms.Stock.Domain;
using Smafac.Wms.Stock.Repositories.Category;

namespace Smafac.Wms.Stock.Services.Category
{
    class StockCategoryAddService : CategoryAddService<StockCategoryEntity, StockCategoryModel>, IStockCategoryAddService
    {
        public StockCategoryAddService(IStockCategoryAddRepository categoryAddRepository,
                                        IStockCategorySearchRepository categorySearchRepository)
        {
            base.CategoryAddRepository = categoryAddRepository;
            base.CategorySearchRepository = categorySearchRepository;
        }
    }
}
