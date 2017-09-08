using Smafac.Framework.Core.Repositories;
using Smafac.Sales.Order.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Repositories
{
    class OrderUpdateRepository : EntityUpdateRepository<OrderContext, OrderEntity>,
                                IOrderUpdateRepository
    {
        public OrderUpdateRepository(OrderContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }

        protected override void SetValue(OrderEntity entity, OrderEntity source)
        {
            entity.Charge = source.Charge;
            entity.HopeDate = source.HopeDate;
            entity.Memo = source.Memo;
            entity.OrderDate = source.OrderDate;
            entity.Price = source.Price;
            entity.Quantity = source.Quantity;
            entity.TotalCharge = source.TotalCharge;
        }
    }
}
