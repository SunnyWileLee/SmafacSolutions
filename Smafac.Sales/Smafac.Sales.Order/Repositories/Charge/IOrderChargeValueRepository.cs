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
        List<OrderChargeValueModel> GetChargeValues(Guid subscriberId, Guid orderId);
        IEnumerable<IGrouping<Guid, OrderChargeValueModel>> GetChargeValues(Guid subscriberId, IEnumerable<Guid> orderIds);
        bool AddChargeValues(Guid orderId, IEnumerable<OrderChargeValueEntity> chargeValues);
        bool UpdateChargeValue(OrderChargeValueModel model);
        bool Any(Guid subscriberId, Guid chargeId);
        bool Delete(Guid subscriberId, Guid chargeId);
    }
}
