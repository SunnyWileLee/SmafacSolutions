using Smafac.Framework.Core.Repositories.Property;
using Smafac.Wms.Stock.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Stock.Repositories.Property
{
    class StockPropertySearchRepository : PropertySearchRepository<StockContext, StockPropertyEntity>, IStockPropertySearchRepository
    {
        public StockPropertySearchRepository(IStockContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}
