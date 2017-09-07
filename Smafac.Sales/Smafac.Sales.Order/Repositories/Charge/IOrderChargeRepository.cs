using Smafac.Sales.Order.Domain;
using Smafac.Sales.Order.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Repositories.Charge
{
    interface IOrderChargeRepository
    {
        bool AddCharge(OrderChargeEntity charge);
        bool UpdateCharge(OrderChargeModel model);
    }
}
