using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Wms.Goods.Models;
using Smafac.Wms.Goods.Domain;

namespace Smafac.Wms.Goods.Repositories
{
    class GoodsCategoryPropertyRepository : IGoodsCategoryPropertyRepository
    {
        private readonly IGoodsContextProvider _goodsContextProvider;

        public GoodsCategoryPropertyRepository(IGoodsContextProvider goodsContextProvider)
        {
            _goodsContextProvider = goodsContextProvider;
        }

        public bool BindProperties(Guid subscriberId, Guid categoryId, IEnumerable<Guid> propertyIds)
        {
            using (var context = _goodsContextProvider.Provide())
            {
                if (!context.GoodsCategories.Any(s => s.SubscriberId == subscriberId && s.Id == categoryId))
                {
                    return false;
                }
                var allPropertyIds = context.GoodsProperties.Where(s => s.SubscriberId == subscriberId).Select(s => s.Id).ToList();
                if (propertyIds.Any(p => !allPropertyIds.Contains(p)))
                {
                    return false;
                }
                var binds = propertyIds.Select(s => new GoodsCategoryPropertyEntity
                {
                    SubscriberId = subscriberId,
                    CategoryId = categoryId,
                    PropertyId = s
                });
                context.GoodsCategoryProperties.AddRange(binds);
                return context.SaveChanges() > 0;
            }
        }

        public List<GoodsPropertyEntity> GetProperties(Guid subscriberId, Guid categoryId)
        {
            using (var context = _goodsContextProvider.Provide())
            {
                var propertyIds = context.GoodsCategoryProperties
                                        .Where(s => s.SubscriberId == subscriberId && s.CategoryId == categoryId)
                                        .Select(s => s.PropertyId).ToList();

                var properties = context.GoodsProperties
                                        .Where(s => s.SubscriberId == subscriberId && propertyIds.Contains(s.Id))
                                        .ToList();
                return properties;
            }
        }

        public bool IsBound(Guid subscriberId, Guid categoryId)
        {
            using (var context = _goodsContextProvider.Provide())
            {
                return context.GoodsCategoryProperties.Any(s => s.SubscriberId == subscriberId && s.CategoryId == categoryId);
            }
        }

        public bool UnbindProperties(Guid subscriberId, Guid categoryId)
        {
            using (var context = _goodsContextProvider.Provide())
            {
                var properties = context.GoodsCategoryProperties.Where(s => s.SubscriberId == subscriberId && s.CategoryId == categoryId);
                context.GoodsCategoryProperties.RemoveRange(properties);
                return context.SaveChanges() > 0;
            }
        }
    }
}
