using Smafac.Sales.Order.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Applications
{
    public interface IOrderChargeService
    {
        bool AddCharge(OrderChargeModel model);
        List<OrderChargeModel> GetCharges();
        bool DeleteCharge(Guid chargeId, bool isDeleteValues);
        bool UpdateCharge(OrderChargeModel model);
    }
}
