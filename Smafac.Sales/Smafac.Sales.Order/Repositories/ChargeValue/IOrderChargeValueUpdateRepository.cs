using Smafac.Framework.Core.Repositories;
using Smafac.Sales.Order.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Repositories.ChargeValue
{
    interface IOrderChargeValueUpdateRepository : IEntityUpdateRepository<OrderChargeValueEntity>
    {
    }
}
