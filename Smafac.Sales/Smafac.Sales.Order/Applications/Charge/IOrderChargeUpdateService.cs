using Smafac.Framework.Core.Applications.CustomizedColumn;
using Smafac.Sales.Order.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Applications.Charge
{
    public interface IOrderChargeUpdateService : ICustomizedColumnUpdateService<OrderChargeModel>
    {
    }
}
