using Smafac.Wms.Goods.Domain;
using Smafac.Wms.Goods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Repositories
{
    class GoodsPropertyValueRepository : IGoodsPropertyValueRepository
    {
        private readonly IGoodsContextProvider _customerContextProvider;

        public GoodsPropertyValueRepository(IGoodsContextProvider customerContextProvider)
        {
            _customerContextProvider = customerContextProvider;
        }

        public bool SetPropertyValue(GoodsPropertyValueEntity value)
        {
            using (var context = _customerContextProvider.Provide())
            {
                var entity = context.GoodsPropertyValues.FirstOrDefault(s => s.SubscriberId == value.SubscriberId && s.GoodsId == value.GoodsId && s.PropertyId == value.PropertyId);
                if (entity == null)
                {
                    context.GoodsPropertyValues.Add(value);
                }
                else
                {
                    entity.Value = value.Value;
                }
                return context.SaveChanges() > 0;
            }
        }

        public List<GoodsPropertyValueModel> GetPropertyValues(Guid SubscriberId, Guid customerId)
        {
            using (var context = _customerContextProvider.Provide())
            {
                var values = context.GoodsPropertyValues.Where(s => s.SubscriberId == SubscriberId && s.GoodsId == customerId);
                return this.JoinProperyName(values, context.GoodsProperties).ToList();
            }
        }

        public IEnumerable<IGrouping<Guid, GoodsPropertyValueModel>> GetPropertyValues(Guid SubscriberId, IEnumerable<Guid> customerIds)
        {
            if (!customerIds.Any())
            {
                throw new ArgumentNullException("customerIds");
            }
            using (var context = _customerContextProvider.Provide())
            {
                var values = context.GoodsPropertyValues.Where(s => s.SubscriberId == SubscriberId && customerIds.Contains(s.GoodsId));
                return this.JoinProperyName(values, context.GoodsProperties).ToList().GroupBy(s => s.GoodsId);
            }
        }

        public bool Any(Guid subscriberId, Guid propertyId)
        {
            using (var context = _customerContextProvider.Provide())
            {
                return context.GoodsPropertyValues.Any(s => s.SubscriberId == subscriberId && s.PropertyId == propertyId);
            }
        }

        public bool AddPropertyValues(Guid subscriberId, Guid goodsId, IEnumerable<GoodsPropertyValueEntity> values)
        {
            using (var context = _customerContextProvider.Provide())
            {
                if (!context.Goods.Any(s => s.Id == goodsId && s.SubscriberId == subscriberId))
                {
                    return false;
                }
                if (context.GoodsPropertyValues.Any(s => s.SubscriberId == subscriberId && s.GoodsId == goodsId))
                {
                    return false;
                }
                if (values.Any(s => s.GoodsId != goodsId || s.SubscriberId != subscriberId))
                {
                    return false;
                }
                context.GoodsPropertyValues.AddRange(values);
                return context.SaveChanges() > 0;
            }
        }

        private IQueryable<GoodsPropertyValueModel> JoinProperyName(IQueryable<GoodsPropertyValueEntity> values,
                                                                    IQueryable<GoodsPropertyEntity> properties)
        {
            var query = from value in values
                        join property in properties on value.PropertyId equals property.Id
                        select new GoodsPropertyValueModel
                        {
                            SubscriberId = value.SubscriberId,
                            CreateTime = value.CreateTime,
                            Id = value.Id,
                            GoodsId = value.GoodsId,
                            PropertyId = value.PropertyId,
                            Value = value.Value,
                            PropertyName = property.Name
                        };
            return query;
        }
    }
}
