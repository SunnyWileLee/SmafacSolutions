using Smafac.Sales.Order.Domain;
using Smafac.Sales.Order.Models;
using System.Linq;

namespace Smafac.Sales.Order.Repositories.Joiners
{
    interface IOrderJoiner
    {
        IQueryable<OrderModel> Join(IQueryable<OrderEntity> goodses, IQueryable<OrderCategoryEntity> categories);
    }
}
