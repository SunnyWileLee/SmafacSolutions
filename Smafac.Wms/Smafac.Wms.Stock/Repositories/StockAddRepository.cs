using Smafac.Framework.Core.Repositories;
using Smafac.Wms.Stock.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Stock.Repositories
{
    class StockAddRepository : EntityAddRepository<StockContext, StockEntity>, IStockAddRepository
    {
        public StockAddRepository(IStockContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}
