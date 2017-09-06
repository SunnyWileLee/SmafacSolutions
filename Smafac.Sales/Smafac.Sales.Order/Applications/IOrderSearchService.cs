using Smafac.Framework.Models;
using Smafac.Sales.Order.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Applications
{
    public interface IOrderSearchService
    {
        OrderPageModel GetOrderPage(OrderPageQueryModel model);
        OrderModel GetOrder(Guid orderId);
        OrderDetailModel GetOrderDetail(Guid orderId);
    }
}
