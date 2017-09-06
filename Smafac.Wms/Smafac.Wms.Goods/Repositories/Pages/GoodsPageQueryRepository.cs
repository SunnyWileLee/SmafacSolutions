using Smafac.Framework.Core.Repositories.Pages;
using Smafac.Wms.Goods.Domain;
using Smafac.Wms.Goods.Models;
using Smafac.Wms.Goods.Repositories.Joiners;
using System.Collections.Generic;
using System.Linq;

namespace Smafac.Wms.Goods.Repositories.Pages
{
    class GoodsPageQueryRepository : PageQueryRepository<GoodsContext, GoodsEntity, GoodsModel>
                                                , IGoodsPageQueryRepository
    {
        private readonly IGoodsJoiner _goodsJoiner;

        public GoodsPageQueryRepository(IGoodsContextProvider contextProvider,
                                        IGoodsJoiner goodsJoiner)
        {
            base.ContextProvider = contextProvider;
            _goodsJoiner = goodsJoiner;
        }

        protected override List<GoodsModel> SelectModel(IQueryable<GoodsEntity> query, GoodsContext context)
        {
            var models = _goodsJoiner.Join(query, context.GoodsCategories);
            return models.ToList();
        }
    }
}
