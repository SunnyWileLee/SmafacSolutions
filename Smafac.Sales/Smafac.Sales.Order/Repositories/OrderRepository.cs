using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Sales.Order.Models;
using Smafac.Sales.Order.Domain;

namespace Smafac.Sales.Order.Repositories
{
    class OrderRepository : IOrderRepository
    {
        private readonly IOrderContextProvider _orderContextProvider;

        public OrderRepository(IOrderContextProvider contextProvider)
        {
            _orderContextProvider = contextProvider;
        }

        public bool AddOrder(OrderEntity order)
        {
            using (var context = _orderContextProvider.Provide())
            {
                context.Orders.Add(order);
                return context.SaveChanges() > 0;
            }
        }

        public bool DeleteOrder(Guid subscriberId, Guid orderId)
        {
            using (var context = _orderContextProvider.Provide())
            {
                var order = context.Orders.FirstOrDefault(s => s.SubscriberId == subscriberId && s.Id == orderId);
                if (order == null)
                {
                    return true;
                }
                context.Orders.Remove(order);
                return context.SaveChanges() > 0;
            }
        }
    }
}
