using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Sales.Order.Domain;
using Smafac.Sales.Order.Models;

namespace Smafac.Sales.Order.Repositories.Joiners
{
    class OrderChargeValueJoiner : IOrderChargeValueJoiner
    {
        public IQueryable<OrderChargeValueModel> Join(IQueryable<OrderChargeValueEntity> values, IQueryable<OrderChargeEntity> charges)
        {
            var query = from value in values
                        join charge in charges on value.ChargeId equals charge.Id
                        select new OrderChargeValueModel
                        {
                            Id = value.Id,
                            SubscriberId = value.SubscriberId,
                            Charge = value.Charge,
                            ChargeId = value.ChargeId,
                            CreateTime = value.CreateTime,
                            OrderId = value.OrderId,
                            ChargeName = charge.Name
                        };
            return query;
        }
    }
}
