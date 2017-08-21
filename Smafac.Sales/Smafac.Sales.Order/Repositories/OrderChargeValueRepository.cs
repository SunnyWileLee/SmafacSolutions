using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Sales.Order.Domain;
using Smafac.Sales.Order.Models;

namespace Smafac.Sales.Order.Repositories
{
    class OrderChargeValueRepository : IOrderChargeValueRepository
    {
        private readonly IOrderContextProvider _orderContextProvider;

        public OrderChargeValueRepository(IOrderContextProvider orderContextProvider)
        {
            _orderContextProvider = orderContextProvider;
        }

        public bool AddChargeValues(Guid orderId, IEnumerable<OrderChargeValueEntity> chargeValues)
        {
            using (var context = _orderContextProvider.Provide())
            {
                if (chargeValues.Any(s => s.OrderId != orderId))
                {
                    return false;
                }
                if (context.OrderChargeValues.Any(s => s.OrderId == orderId))
                {
                    return false;
                }
                context.OrderChargeValues.AddRange(chargeValues);
                return context.SaveChanges() > 0;
            }
        }

        public List<OrderChargeValueModel> GetChargeValues(Guid subscriberId, Guid orderId)
        {
            using (var context = _orderContextProvider.Provide())
            {
                var query = from value in context.OrderChargeValues
                            join charge in context.OrderCharges on value.ChargeId equals charge.Id
                            where value.SubscriberId == subscriberId && value.OrderId == orderId
                            select new OrderChargeValueModel
                            {
                                Id = value.Id,
                                SubscriberId = value.SubscriberId,
                                Charge = value.Charge,
                                ChargeId = value.ChargeId,
                                CreateTime = value.CreateTime,
                                OrderId = value.OrderId,
                                ChargeName = charge.Name
                            };
                return query.ToList();
            }
        }

        public IEnumerable<IGrouping<Guid, OrderChargeValueEntity>> GetChargeValues(Guid subscriberId, IEnumerable<Guid> orderIds)
        {
            using (var context = _orderContextProvider.Provide())
            {
                var values = context.OrderChargeValues.Where(s => s.SubscriberId == subscriberId && orderIds.Contains(s.OrderId))
                                                    .ToList();
                return values.GroupBy(s => s.OrderId);
            }
        }

        public bool UpdateChargeValue(OrderChargeValueModel model)
        {
            using (var context = _orderContextProvider.Provide())
            {
                var value = context.OrderChargeValues.FirstOrDefault(s => s.SubscriberId == model.SubscriberId && s.Id == model.Id);
                if (value == null)
                {
                    return false;
                }
                value.Charge = model.Charge;
                return context.SaveChanges() > 0;
            }
        }
    }
}
