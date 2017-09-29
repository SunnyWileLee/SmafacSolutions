using Smafac.Wms.Goods.Domain;
using Smafac.Wms.Goods.Models;
using System.Linq;

namespace Smafac.Wms.Goods.Repositories.Joiners
{
    class GoodsJoiner : IGoodsJoiner
    {
        public IQueryable<GoodsModel> Join(IQueryable<GoodsEntity> goodses, IQueryable<GoodsCategoryEntity> categories)
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
                            Price = goods.Price,
                            Saleable = category.Saleable,
                            Purchaseable = category.Purchaseable
                        };
            return query;
        }
    }
}
