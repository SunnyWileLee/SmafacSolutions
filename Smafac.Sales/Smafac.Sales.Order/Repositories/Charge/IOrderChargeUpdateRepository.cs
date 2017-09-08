using Smafac.Framework.Core.Repositories.CustomizedColumn;
using Smafac.Sales.Order.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Repositories.Charge
{
    interface IOrderChargeUpdateRepository: ICustomizedColumnUpdateRepository<OrderChargeEntity>
    {
    }
}
