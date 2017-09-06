using Smafac.Sales.Order.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Repositories.Charge
{
    interface IOrderChargeValueSearchRepository
    {
        List<OrderChargeValueModel> GetChargeValues(Guid subscriberId, Guid orderId);
        IEnumerable<IGrouping<Guid, OrderChargeValueModel>> GetChargeValues(Guid subscriberId, IEnumerable<Guid> orderIds);
        bool Any(Guid subscriberId, Guid chargeId);
    }
}
