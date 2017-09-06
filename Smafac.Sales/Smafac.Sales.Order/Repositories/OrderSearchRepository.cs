using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Smafac.Sales.Order.Domain;
using Smafac.Framework.Core.Repositories;
using Smafac.Sales.Order.Domain.Pages;

namespace Smafac.Sales.Order.Repositories
{
    class OrderSearchRepository : EntityRepository<OrderContext, OrderEntity>, IOrderSearchRepository
    {
        public OrderSearchRepository(IOrderContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }

        public OrderEntity GetById(Guid subscriberId, Guid orderId)
        {
            using (var context = ContextProvider.Provide())
            {
                var order = context.Orders.FirstOrDefault(s => s.SubscriberId == subscriberId && s.Id == orderId);
                return order;
            }
        }
    }
}
