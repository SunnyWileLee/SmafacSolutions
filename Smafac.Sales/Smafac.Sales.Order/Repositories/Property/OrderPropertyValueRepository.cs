using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Sales.Order.Domain;
using Smafac.Sales.Order.Models;

namespace Smafac.Sales.Order.Repositories.Property
{
    class OrderPropertyValueRepository : IOrderPropertyValueRepository
    {
        private readonly IOrderContextProvider _orderContextProvider;

        public OrderPropertyValueRepository(IOrderContextProvider orderContextProvider)
        {
            _orderContextProvider = orderContextProvider;
        }

        public bool AddPropertyValues(Guid orderId, IEnumerable<OrderPropertyValueEntity> values)
        {
            using (var context = _orderContextProvider.Provide())
            {
                if (values.Any(s => s.OrderId != orderId))
                {
                    return false;
                }
                if (context.OrderPropertyValues.Any(s => s.OrderId == orderId))
                {
                    return false;
                }
                context.OrderPropertyValues.AddRange(values);
                return context.SaveChanges() > 0;
            }
        }

        public bool Any(Guid subscriberId, Guid propertyId)
        {
            using (var context = _orderContextProvider.Provide())
            {
                return context.OrderPropertyValues.Any(s => s.SubscriberId == subscriberId && s.PropertyId == propertyId);
            }
        }

        public bool Delete(Guid subscriberId, Guid propertyId)
        {
            using (var context = _orderContextProvider.Provide())
            {
                var properties = context.OrderPropertyValues.Where(s => s.SubscriberId == subscriberId && s.PropertyId == propertyId).ToList();
                if (!properties.Any())
                {
                    return true;
                }
                context.OrderPropertyValues.RemoveRange(properties);
                return context.SaveChanges() > 0;
            }
        }

        public List<OrderPropertyValueModel> GetPropertyValues(Guid subscriberId, Guid orderId)
        {
            using (var context = _orderContextProvider.Provide())
            {
                var query = from value in context.OrderPropertyValues
                            join property in context.OrderProperties on value.PropertyId equals property.Id
                            where value.SubscriberId == subscriberId && value.OrderId == orderId
                            select new OrderPropertyValueModel
                            {
                                Id = value.Id,
                                SubscriberId = value.SubscriberId,
                                CreateTime = value.CreateTime,
                                OrderId = value.OrderId,
                                PropertyId = value.PropertyId,
                                PropertyName = property.Name,
                                Value = value.Value
                            };
                return query.ToList();
            }
        }

        public IEnumerable<IGrouping<Guid, OrderPropertyValueModel>> GetPropertyValues(Guid subscriberId, IEnumerable<Guid> orderIds)
        {
            using (var context = _orderContextProvider.Provide())
            {
                var query = from value in context.OrderPropertyValues
                            join property in context.OrderProperties on value.PropertyId equals property.Id
                            where value.SubscriberId == subscriberId && orderIds.Contains(value.OrderId)
                            select new OrderPropertyValueModel
                            {
                                Id = value.Id,
                                SubscriberId = value.SubscriberId,
                                CreateTime = value.CreateTime,
                                OrderId = value.OrderId,
                                PropertyId = value.PropertyId,
                                PropertyName = property.Name,
                                Value = value.Value
                            };
                return query.ToList().GroupBy(s => s.OrderId);
            }
        }

        public bool UpdatePropertyValue(OrderPropertyValueModel model)
        {
            using (var context = _orderContextProvider.Provide())
            {
                var property = context.OrderPropertyValues.FirstOrDefault(s => s.SubscriberId == model.SubscriberId && s.Id == model.Id);
                if (property == null)
                {
                    return false;
                }
                property.Value = model.Value;
                return context.SaveChanges() > 0;
            }
        }
    }
}
