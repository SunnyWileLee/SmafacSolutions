using Smafac.Framework.Core.Domain.Pages;
using Smafac.Sales.Order.Models;

namespace Smafac.Sales.Order.Domain.Pages
{
    interface IOrderPageQueryer : IPageQueryer<OrderModel, OrderPageQueryModel>
    {
        OrderPageModel QueryPage(OrderPageQueryModel query);
    }
}
