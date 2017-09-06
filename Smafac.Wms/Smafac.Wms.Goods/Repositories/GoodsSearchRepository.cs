using Smafac.Framework.Core.Repositories;
using Smafac.Wms.Goods.Domain;
using Smafac.Wms.Goods.Models;
using Smafac.Wms.Goods.Repositories.Joiners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Repositories
{
    class GoodsSearchRepository : EntityRepository<GoodsContext, GoodsEntity>, IGoodsSearchRepository
    {
        private readonly IGoodsJoiner _goodsJoiner;

        public GoodsSearchRepository(IGoodsContextProvider goodsContextProvider,
                                    IGoodsJoiner goodsJoiner)
        {
            base.ContextProvider = goodsContextProvider;
            _goodsJoiner = goodsJoiner;
        }

        public List<GoodsModel> GetGoods(Guid subscriberId, Expression<Func<GoodsEntity, bool>> predicate)
        {
            using (var context = ContextProvider.Provide())
            {
                var goodses = context.Goods.Where(s => s.SubscriberId == subscriberId).Where(predicate);
                return _goodsJoiner.Join(goodses, context.GoodsCategories).ToList();
            }
        }

        public GoodsModel GetGoods(Guid subscriberId, Guid goodsId)
        {
            using (var context = ContextProvider.Provide())
            {
                var goodses = context.Goods.Where(s => s.SubscriberId == subscriberId && s.Id == goodsId);
                return _goodsJoiner.Join(goodses, context.GoodsCategories).FirstOrDefault();
            }
        }
    }
}
