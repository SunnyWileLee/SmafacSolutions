using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Sales.Order.Domain;
using Smafac.Sales.Order.Models;
using Smafac.Framework.Core.Repositories;

namespace Smafac.Sales.Order.Repositories.ChargeValue
{
    class OrderChargeValueRepository : EntityAddRepository<OrderContext, OrderChargeValueEntity>,
                                        IOrderChargeValueRepository
    {
        public OrderChargeValueRepository(IOrderContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }

        public bool AddChargeValues(Guid orderId, IEnumerable<OrderChargeValueEntity> chargeValues)
        {
            using (var context = ContextProvider.Provide())
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

        public bool Delete(Guid subscriberId, Guid chargeId)
        {
            using (var context = ContextProvider.Provide())
            {
                var charges = context.OrderChargeValues.Where(s => s.SubscriberId == subscriberId && s.ChargeId == chargeId).ToList();
                if (!charges.Any())
                {
                    return true;
                }
                context.OrderChargeValues.RemoveRange(charges);
                return context.SaveChanges() > 0;
            }
        }

        public bool UpdateChargeValue(OrderChargeValueModel model)
        {
            using (var context = ContextProvider.Provide())
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
