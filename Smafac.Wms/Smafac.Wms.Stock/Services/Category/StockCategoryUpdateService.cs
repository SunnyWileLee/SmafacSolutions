using Smafac.Framework.Core.Services.Category;
using Smafac.Wms.Stock.Applications.Category;
using Smafac.Wms.Stock.Domain;
using Smafac.Wms.Stock.Models;
using Smafac.Wms.Stock.Repositories.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Stock.Services.Category
{
    class StockCategoryUpdateService : CategoryUpdateService<StockCategoryEntity, StockCategoryModel>, IStockCategoryUpdateService
    {
        public StockCategoryUpdateService(IStockCategorySearchRepository categorySearchRepository,
                                          IStockCategoryUpdateRepository categoryUpdateRepository)
        {
            base.CategorySearchRepository = categorySearchRepository;
            base.CategoryUpdateRepository = categoryUpdateRepository;
        }
    }
}
