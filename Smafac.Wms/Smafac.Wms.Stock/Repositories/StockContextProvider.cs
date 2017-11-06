using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Stock.Repositories
{
    class StockContextProvider : IStockContextProvider
    {
        public StockContext Provide()
        {
            return new StockContext();
        }

        public StockContext ProvideSlave()
        {
            return new StockContext();
        }
    }
}
