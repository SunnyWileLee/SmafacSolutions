using Smafac.Framework.Core.Repositories.Property;
using Smafac.Wms.Stock.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Stock.Repositories.Property
{
    class StockPropertyUpdateRepository : PropertyUpdateRepository<StockContext, StockPropertyEntity>, IStockPropertyUpdateRepository
    {
        public StockPropertyUpdateRepository(IStockContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}
