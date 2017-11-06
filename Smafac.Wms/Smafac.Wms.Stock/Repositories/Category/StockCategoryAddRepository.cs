using Smafac.Framework.Core.Repositories.Category;
using Smafac.Wms.Stock.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Stock.Repositories.Category
{
    class StockCategoryAddRepository : CategoryAddRepository<StockContext, StockCategoryEntity>, IStockCategoryAddRepository
    {
        public StockCategoryAddRepository(IStockContextProvider contextProvider)
        {
            base.ContextProvider  = contextProvider;
        }
    }
}
