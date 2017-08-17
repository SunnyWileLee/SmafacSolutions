using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Wms.Goods.Domain;

namespace Smafac.Wms.Goods.Repositories
{
    class GoodsCategoryRepository : IGoodsCategoryRepository
    {
        private readonly IGoodsContextProvider _goodsContextProvider;

        public GoodsCategoryRepository(IGoodsContextProvider goodsContextProvider)
        {
            _goodsContextProvider = goodsContextProvider;
        }

        public bool AddCategory(GoodsCategoryEntity entity)
        {
            using (var context = _goodsContextProvider.Provide())
            {
                context.GoodsCategories.Add(entity);
                return context.SaveChanges() > 0;
            }
        }

        public bool DeleteCategory(Guid subscriberId, Guid categoryId)
        {
            using (var context = _goodsContextProvider.Provide())
            {
                var category = context.GoodsCategories.FirstOrDefault(s => s.SubscriberId == subscriberId && s.Id == categoryId);
                if (category == null)
                {
                    return true;
                }
                context.GoodsCategories.Remove(category);
                return context.SaveChanges() > 0;
            }
        }

        public List<GoodsCategoryEntity> GetCategories(Guid subscriberId, Guid parentId)
        {
            using (var context = _goodsContextProvider.Provide())
            {
                var categories = context.GoodsCategories
                                .Where(s => s.SubscriberId == subscriberId && s.ParentId == parentId)
                                .ToList();
                return categories;
            }
        }

        public bool UpdateCategory(GoodsCategoryEntity entity)
        {
            using (var context = _goodsContextProvider.Provide())
            {
                var category = context.GoodsCategories
                                .FirstOrDefault(s => s.SubscriberId == entity.SubscriberId && s.Id == entity.Id);
                if (category == null)
                {
                    return false;
                }
                category.Name = entity.Name;
                category.ParentId = entity.ParentId;
                return context.SaveChanges() > 0;
            }
        }
    }
}
