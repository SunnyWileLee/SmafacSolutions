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

        public List<GoodsModel> GetGoods(Guid subscriberId, Expression<Func<GoodsEntity, bool>> predicate)
        {
            using (var context = _goodsContextProvider.Provide())
            {
                var goodses = context.Goods.Where(s => s.SubscriberId == subscriberId).Where(predicate);
                return JoinCategory(goodses, context.GoodsCategories).ToList();
            }
        }

        public List<GoodsModel> GetGoodsPage(Guid subscriberId, Expression<Func<GoodsEntity, bool>> predicate, int skip, int take)
        {
            using (var context = _goodsContextProvider.Provide())
            {
                var goodses = context.Goods.Where(s => s.SubscriberId == subscriberId)
                                        .Where(predicate).OrderByDescending(s => s.CreateTime)
                                        .Skip(skip).Take(take);
                return JoinCategory(goodses, context.GoodsCategories).ToList();
            }
        }

        private IQueryable<GoodsModel> JoinCategory(IQueryable<GoodsEntity> goodses, IQueryable<GoodsCategoryEntity> categories)
        {
            var query = from goods in goodses
                        join category in categories on goods.CategoryId equals category.Id
                        select new GoodsModel
                        {
                            CategoryId = goods.CategoryId,
                            SubscriberId = goods.SubscriberId,
                            CategoryName = category.Name,
                            CreateTime = goods.CreateTime,
                            Id = goods.Id,
                            Name = goods.Name,
                            Price = goods.Price
                        };
            return query;
        }

        public int GetGoodsCount(Guid subscriberId, Expression<Func<GoodsEntity, bool>> predicate)
        {
            using (var context = _goodsContextProvider.Provide())
            {
                var count = context.Goods.Where(s => s.SubscriberId == subscriberId).Count(predicate);
                return count;
            }
        }

        public GoodsModel GetGoods(Guid subscriberId, Guid goodsId)
        {
            using (var context = _goodsContextProvider.Provide())
            {
                var goodses = context.Goods.Where(s => s.SubscriberId == subscriberId && s.Id == goodsId);
                return JoinCategory(goodses, context.GoodsCategories).ToList().FirstOrDefault();
            }
        }
    }
}
