using Smafac.Framework.Core.Repositories;
using Smafac.Wms.Stock.Domain;
using Smafac.Wms.Stock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Stock.Repositories
{
    interface IStockSearchRepository : IEntitySearchRepository<StockEntity>
    {
        StockModel GetStock(Guid subscriberId, Guid goodsId);
        List<StockModel> GetStock(Guid subscriberId, Expression<Func<StockEntity, bool>> predicate);
    }
}
