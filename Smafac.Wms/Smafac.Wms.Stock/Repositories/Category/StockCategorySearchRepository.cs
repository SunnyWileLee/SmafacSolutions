using Smafac.Framework.Core.Repositories.Category;
using Smafac.Wms.Stock.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Stock.Repositories.Category
{
    class StockCategorySearchRepository : CategorySearchRepository<StockContext, StockCategoryEntity>, IStockCategorySearchRepository
    {
        public StockCategorySearchRepository(IStockContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}
