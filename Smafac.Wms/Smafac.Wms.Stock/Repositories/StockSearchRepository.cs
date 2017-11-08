using Smafac.Framework.Core.Repositories;
using Smafac.Wms.Stock.Domain;
using Smafac.Wms.Stock.Models;
using Smafac.Wms.Stock.Repositories.Joiners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Stock.Repositories
{
    class StockSearchRepository : EntitySearchRepository<StockContext, StockEntity>, IStockSearchRepository
    {
        private readonly IStockJoiner _goodsJoiner;

        public StockSearchRepository(IStockContextProvider contextProvider,
                                    IStockJoiner goodsJoiner)
        {
            base.ContextProvider = contextProvider;
            _goodsJoiner = goodsJoiner;
        }

        public List<StockModel> GetStock(Guid subscriberId, Expression<Func<StockEntity, bool>> predicate)
        {
            using (var context = ContextProvider.Provide())
            {
                var goodses = context.Stocks.Where(s => s.SubscriberId == subscriberId).Where(predicate);
                return _goodsJoiner.Join(goodses, context.StockCategories).ToList();
            }
        }

        public StockModel GetStock(Guid subscriberId, Guid goodsId)
        {
            using (var context = ContextProvider.Provide())
            {
                var goodses = context.Stocks.Where(s => s.SubscriberId == subscriberId && s.Id == goodsId);
                return _goodsJoiner.Join(goodses, context.StockCategories).FirstOrDefault();
            }
        }
    }
}
