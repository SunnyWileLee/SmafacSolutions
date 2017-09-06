using Smafac.Sales.Order.Domain;
using Smafac.Sales.Order.Models;
using System.Linq;

namespace Smafac.Sales.Order.Repositories.Joiners
{
    class OrderJoiner : IOrderJoiner
    {
        public IQueryable<OrderModel> Join(IQueryable<OrderEntity> orders, IQueryable<OrderCategoryEntity> categories)
        {
            var query = from order in orders
                        join category in categories on order.CategoryId equals category.Id
                        select new OrderModel
                        {
                            CategoryId = order.CategoryId,
                            SubscriberId = order.SubscriberId,
                            CategoryName = category.Name,
                            CreateTime = order.CreateTime,
                            Id = order.Id,
                            Charge = order.Charge,
                            CustomerId = order.CustomerId,
                            HopeDate = order.HopeDate,
                            Memo = order.Memo,
                            OrderDate = order.OrderDate,
                            Quantity = order.Quantity,
                            GoodsId = order.GoodsId,
                            TotalCharge = order.TotalCharge,
                            Price = order.Price
                        };
            return query;
        }
    }
}
