using Smafac.Sales.Order.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Applications.Charge
{
    public interface IOrderChargeSearchService
    {
        List<OrderChargeModel> GetCharges();
        List<OrderChargeModel> GetCharges(Guid orderId);
    }
}
