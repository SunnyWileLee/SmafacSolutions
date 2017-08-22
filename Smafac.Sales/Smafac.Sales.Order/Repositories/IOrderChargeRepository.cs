using Smafac.Sales.Order.Domain;
using Smafac.Sales.Order.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Repositories
{
    interface IOrderChargeRepository
    {
        bool AddCharge(OrderChargeEntity charge);
        bool DeleteCharge(Guid subscriberId, Guid chargeId);
        bool UpdateCharge(OrderChargeModel model);
        List<OrderChargeEntity> GetCharges(Guid subscriberId);
        bool Any(Guid subscriberId, string name);
    }
}
