using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Smafac.Sales.Order.Domain;

namespace Smafac.Sales.Order.Repositories
{
    class OrderSearchRepository : IOrderSearchRepository
    {
        private readonly IOrderContextProvider _orderContextProvider;

        public OrderSearchRepository(IOrderContextProvider orderContextProvider)
        {
            _orderContextProvider = orderContextProvider;
        }

        public OrderEntity GetById(Guid subscriberId, Guid orderId)
        {
            using (var context = _orderContextProvider.Provide())
            {
                var order = context.Orders.FirstOrDefault(s => s.SubscriberId == subscriberId && s.Id == orderId);
                return order;
            }
        }

        public int GetOrderCount(Guid subscriberId, Expression<Func<OrderEntity, bool>> predicate)
        {
            using (var context = _orderContextProvider.Provide())
            {
                var count = context.Orders.Where(s => s.SubscriberId == subscriberId).Count(predicate);
                return count;
            }
        }

        public List<OrderEntity> GetOrderPage(Guid subscriberId, Expression<Func<OrderEntity, bool>> predicate, int skip, int take)
        {
            using (var context = _orderContextProvider.Provide())
            {
                var orders = context.Orders.Where(s => s.SubscriberId == subscriberId)
                                        .Where(predicate).OrderByDescending(s => s.CreateTime)
                                        .Skip(skip).Take(take).ToList();
                return orders;
            }
        }
    }
}
