using Smafac.Framework.Core.Repositories.Pages;
using Smafac.Sales.Order.Domain;
using Smafac.Sales.Order.Models;

namespace Smafac.Sales.Order.Repositories.Pages
{
    interface IOrderPageQueryRepository : IPageQueryRepository<OrderEntity, OrderModel>
    {

    }
}
