using Smafac.Wms.Goods.Domain;
using Smafac.Wms.Goods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Repositories
{
    class GoodsPropertyRepository : IGoodsPropertyRepository
    {
        private readonly IGoodsContextProvider _goodsContextProvider;

        public GoodsPropertyRepository(IGoodsContextProvider goodsContextProvider)
        {
            _goodsContextProvider = goodsContextProvider;
        }

        public bool AddProperty(GoodsPropertyEntity property)
        {
            using (var context = _goodsContextProvider.Provide())
            {
                context.GoodsProperties.Add(property);
                return context.SaveChanges() > 0;
            }
        }

        public bool Any(Guid subscriberId, string name)
        {
            using (var context = _goodsContextProvider.Provide())
            {
                return context.GoodsProperties.Any(s => s.SubscriberId == subscriberId && s.Name.Equals(name));
            }
        }

        public bool DeleteProperty(Guid subscriberId, Guid propertyId)
        {
            using (var context = _goodsContextProvider.Provide())
            {
                var property = context.GoodsProperties.FirstOrDefault(s => s.SubscriberId == subscriberId && s.Id == propertyId);
                if (property == null)
                {
                    return true;
                }
                context.GoodsProperties.Remove(property);
                return context.SaveChanges() > 0;
            }
        }

        public List<GoodsPropertyEntity> GetProperties(Guid subscriberId)
        {
            using (var context = _goodsContextProvider.Provide())
            {
                var properties = context.GoodsProperties.Where(s => s.SubscriberId == subscriberId).ToList();
                return properties;
            }
        }

        public bool IsUsed(Guid subscriberId, Guid propertyId)
        {
            using (var context = _goodsContextProvider.Provide())
            {
                var any = context.GoodsCategoryProperties.Any(s => s.SubscriberId == subscriberId && s.PropertyId ==propertyId);
                return any;
            }
        }

        public bool UpdateProperty(GoodsPropertyModel model)
        {
            using (var context = _goodsContextProvider.Provide())
            {
                var property = context.GoodsProperties.FirstOrDefault(s => s.SubscriberId == model.SubscriberId && s.Id == model.Id);
                if (property == null)
                {
                    return false;
                }
                property.Name = model.Name;
                return context.SaveChanges() > 0;
            }
        }
    }
}
