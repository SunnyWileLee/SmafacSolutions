using Smafac.Sales.Order.Domain;
using Smafac.Sales.Order.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Repositories
{
    interface IOrderRepository
    {
        bool AddOrder(OrderEntity order);
        bool DeleteOrder(Guid subscriberId, Guid orderId);
    }
}
