using Smafac.Framework.Core.Repositories.CategoryProperty;
using Smafac.Wms.Stock.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Stock.Repositories.CategoryProperty
{
    class StockCategoryPropertyBindRepository : CategoryPropertyBindRepository<StockContext, StockCategoryEntity, StockPropertyEntity, StockCategoryPropertyEntity>,
                                                IStockCategoryPropertyBindRepository
    {
        public StockCategoryPropertyBindRepository(IStockContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}
