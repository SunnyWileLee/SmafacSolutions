using Smafac.Sales.Order.Domain;
using Smafac.Sales.Order.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Repositories.Charge
{
    interface IOrderChargeValueRepository
    {
        bool AddChargeValues(Guid orderId, IEnumerable<OrderChargeValueEntity> chargeValues);
        bool UpdateChargeValue(OrderChargeValueModel model);
        bool Delete(Guid subscriberId, Guid chargeId);
    }
}
