using Smafac.Wms.Goods.Domain;
using Smafac.Wms.Goods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Repositories
{
    class GoodsPropertyValueRepository: IGoodsPropertyValueRepository
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
                var values = context.GoodsPropertyValues.Where(s => s.SubscriberId == SubscriberId && s.GoodsId == customerId)
                                    .Select(s => new GoodsPropertyValueModel
                                    {
                                        SubscriberId = s.SubscriberId,
                                        CreateTime = s.CreateTime,
                                        Id = s.Id,
                                        GoodsId = s.GoodsId,
                                        PropertyId = s.PropertyId,
                                        Value = s.Value
                                    }).ToList();
                return values;
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
                var values = context.GoodsPropertyValues.Where(s => s.SubscriberId == SubscriberId && customerIds.Contains(s.GoodsId))
                                    .Select(s => new GoodsPropertyValueModel
                                    {
                                        SubscriberId = s.SubscriberId,
                                        CreateTime = s.CreateTime,
                                        Id = s.Id,
                                        GoodsId = s.GoodsId,
                                        PropertyId = s.PropertyId,
                                        Value = s.Value
                                    }).ToList();
                return values.GroupBy(s => s.GoodsId);
            }
        }

        public bool Any(Guid subscriberId, Guid propertyId)
        {
            using (var context = _customerContextProvider.Provide())
            {
                return context.GoodsPropertyValues.Any(s => s.SubscriberId == subscriberId && s.PropertyId == propertyId);
            }
        }
    }
}
