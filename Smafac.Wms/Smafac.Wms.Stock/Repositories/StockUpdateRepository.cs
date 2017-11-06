using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Wms.Stock.Models;
using Smafac.Framework.Core.Repositories;
using Smafac.Wms.Stock.Domain;

namespace Smafac.Wms.Stock.Repositories
{
    class StockUpdateRepository : EntityUpdateRepository<StockContext, StockEntity>,
                                    IStockUpdateRepository
    {
        public StockUpdateRepository(IStockContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }

        protected override void SetValue(StockEntity entity, StockEntity source)
        {
            entity.Quantity = source.Quantity;
            entity.StockDate = source.StockDate;
        }
    }
}
