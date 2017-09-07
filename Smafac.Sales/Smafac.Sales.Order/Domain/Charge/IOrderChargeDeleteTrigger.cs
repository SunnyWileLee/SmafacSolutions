using Smafac.Framework.Core.Domain.CustomizedColumn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Domain.Charge
{
    interface IOrderChargeDeleteTrigger : ICustomizedColumnDeleteTrigger<OrderChargeEntity>
    {
    }
}
