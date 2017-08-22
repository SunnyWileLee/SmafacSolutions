using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Sales.Order.Domain;
using Smafac.Sales.Order.Models;

namespace Smafac.Sales.Order.Repositories
{
    class OrderPropertyRepository : IOrderPropertyRepository
    {
        private readonly IOrderContextProvider _orderContextProvider;

        public OrderPropertyRepository(IOrderContextProvider orderContextProvider)
        {
            _orderContextProvider = orderContextProvider;
        }

        public bool AddProperty(OrderPropertyEntity property)
        {
            using (var context = _orderContextProvider.Provide())
            {
                context.OrderProperties.Add(property);
                return context.SaveChanges() > 0;
            }
        }

        public bool Any(Guid subscriberId, string name)
        {
            using (var context = _orderContextProvider.Provide())
            {
                return context.OrderProperties.Any(s => s.SubscriberId == subscriberId && s.Name.Equals(name));
            }
        }

        public bool DeleteProperty(Guid subscriberId, Guid propertyId)
        {
            using (var context = _orderContextProvider.Provide())
            {
                var property = context.OrderProperties.FirstOrDefault(s => s.SubscriberId == subscriberId && s.Id == propertyId);
                if (property == null)
                {
                    return true;
                }
                context.OrderProperties.Remove(property);
                return context.SaveChanges() > 0;
            }
        }

        public List<OrderPropertyEntity> GetProperties(Guid subscriberId)
        {
            using (var context = _orderContextProvider.Provide())
            {
                var properties = context.OrderProperties.Where(s => s.SubscriberId == subscriberId).ToList();
                return properties;
            }
        }

        public bool UpdateProperty(OrderPropertyModel model)
        {
            using (var context = _orderContextProvider.Provide())
            {
                var property = context.OrderProperties.FirstOrDefault(s => s.SubscriberId == model.SubscriberId && s.Id == model.Id);
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
