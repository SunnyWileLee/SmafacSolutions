using Smafac.Sales.Order.Domain;
using Smafac.Sales.Order.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Repositories
{
    interface IOrderSearchRepository
    {
        OrderEntity GetById(Guid subscriberId, Guid orderId);
        List<OrderEntity> GetOrderPage(Guid subscriberId, Expression<Func<OrderEntity, bool>> predicate, int skip, int take);
        int GetOrderCount(Guid subscriberId, Expression<Func<OrderEntity, bool>> predicate);
    }
}
