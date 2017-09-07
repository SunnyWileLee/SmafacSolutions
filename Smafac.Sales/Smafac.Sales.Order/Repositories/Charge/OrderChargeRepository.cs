using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Sales.Order.Domain;
using Smafac.Sales.Order.Models;

namespace Smafac.Sales.Order.Repositories.Charge
{
    class OrderChargeRepository : IOrderChargeRepository
    {
        private readonly IOrderContextProvider _orderContextProvider;

        public OrderChargeRepository(IOrderContextProvider orderContextProvider)
        {
            _orderContextProvider = orderContextProvider;
        }

        public bool AddCharge(OrderChargeEntity charge)
        {
            using (var context = _orderContextProvider.Provide())
            {
                context.OrderCharges.Add(charge);
                return context.SaveChanges() > 0;
            }
        }

        public bool UpdateCharge(OrderChargeModel model)
        {
            using (var context = _orderContextProvider.Provide())
            {
                var charge = context.OrderCharges.FirstOrDefault(s => s.SubscriberId == model.SubscriberId && s.Id == model.Id);
                if (charge == null)
                {
                    return false;
                }
                charge.Name = model.Name;
                return context.SaveChanges() > 0;
            }
        }
    }
}
