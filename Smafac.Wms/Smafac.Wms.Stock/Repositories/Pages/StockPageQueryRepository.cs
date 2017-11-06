using Smafac.Framework.Core.Repositories.Pages;
using Smafac.Wms.Stock.Domain;
using Smafac.Wms.Stock.Models;
using Smafac.Wms.Stock.Repositories.Joiners;
using System.Collections.Generic;
using System.Linq;

namespace Smafac.Wms.Stock.Repositories.Pages
{
    class StockPageQueryRepository : PageQueryRepository<StockContext, StockEntity, StockModel>
                                                , IStockPageQueryRepository
    {
        private readonly IStockJoiner _goodsJoiner;

        public StockPageQueryRepository(IStockContextProvider contextProvider,
                                        IStockJoiner goodsJoiner)
        {
            base.ContextProvider = contextProvider;
            _goodsJoiner = goodsJoiner;
        }

        protected override List<StockModel> SelectModel(IQueryable<StockEntity> query, StockContext context)
        {
            var models = _goodsJoiner.Join(query, context.StockCategories);
            return models.ToList();
        }
    }
}
