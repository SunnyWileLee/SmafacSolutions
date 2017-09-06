using Smafac.Sales.Order.Domain;
using Smafac.Sales.Order.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Repositories.Joiners
{
    interface IOrderChargeValueJoiner
    {
        IQueryable<OrderChargeValueModel> Join(IQueryable<OrderChargeValueEntity> values, IQueryable<OrderChargeEntity> charges);
    }
}
