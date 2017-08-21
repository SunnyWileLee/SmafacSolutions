using Smafac.Sales.Order.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Applications
{
    public interface IOrderService
    {
        bool AddOrder(OrderModel model);
        bool UpdateOrder(OrderModel model);
        bool DeleteOrder(Guid orderId);
        OrderModel CreateEmptyOrder();
    }
}
