using Smafac.Framework.Core.Services.Category;
using Smafac.Wms.Stock.Applications.Category;
using Smafac.Wms.Stock.Domain;
using Smafac.Wms.Stock.Domain.Property;
using Smafac.Wms.Stock.Models;
using Smafac.Wms.Stock.Repositories.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Stock.Services.Category
{
    class StockCategorySearchService : CategorySearchService<StockCategoryEntity, StockCategoryModel>, IStockCategorySearchService
    {
        public StockCategorySearchService(IStockCategorySearchRepository searchRepository,
            IStockPropertyProvider categoryProvider)
        {
            base.CategorySearchRepository = searchRepository;
        }
    }
}
