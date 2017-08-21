using Smafac.Wms.Goods.Domain;
using Smafac.Wms.Goods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Repositories
{
    class GoodsSearchRepository : IGoodsSearchRepository
    {
        private readonly IGoodsContextProvider _goodsContextProvider;

        public GoodsSearchRepository(IGoodsContextProvider goodsContextProvider)
        {
            _goodsContextProvider = goodsContextProvider;
        }

        public List<GoodsEntity> GetGoods(Guid subscriberId, Expression<Func<GoodsEntity, bool>> predicate)
        {
            using (var context = _goodsContextProvider.Provide())
            {
                var goods = context.Goods.Where(s => s.SubscriberId == subscriberId).Where(predicate)
                                .ToList();                            
                return goods;
            }
        }

        public List<GoodsModel> GetGoodsPage(Guid subscriberId, Expression<Func<GoodsEntity, bool>> predicate, int skip, int take)
        {
            using (var context = _goodsContextProvider.Provide())
            {
                var goods = context.Goods.Where(s=>s.SubscriberId==subscriberId).Where(predicate).Skip(skip).Take(take)
                                 .Select(s => new GoodsModel { Name = s.Name, Price = s.Price }).ToList();
                return goods;
            }
        }


        public int GetGoodsCount(Guid subscriberId, Expression<Func<GoodsEntity, bool>> predicate)
        {
            using (var context = _goodsContextProvider.Provide())
            {
                var count = context.Goods.Where(s => s.SubscriberId == subscriberId).Count(predicate);
                return count;
            }
        }
    }
}
