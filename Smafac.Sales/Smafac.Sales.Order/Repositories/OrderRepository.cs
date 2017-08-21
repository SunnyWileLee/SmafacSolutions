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

        public OrderRepository(IOrderContextProvider orderContextProvider)
        {
            _orderContextProvider = orderContextProvider;
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

        public bool UpdateOrder(OrderModel model)
        {
            using (var context = _orderContextProvider.Provide())
            {
                var order = context.Orders.FirstOrDefault(s => s.SubscriberId == model.SubscriberId && s.Id == model.Id);
                if (order == null)
                {
                    return false;
                }
                order.GoodsId = model.GoodsId;
                order.Quantity = model.Quantity;
                order.Amount = model.Amount;
                order.CustomerId = model.CustomerId;
                order.HopeDate = model.HopeDate;
                order.OrderDate = model.OrderDate;
                order.Memo = model.Memo;
                return context.SaveChanges() > 0;
            }
        }
    }
}
