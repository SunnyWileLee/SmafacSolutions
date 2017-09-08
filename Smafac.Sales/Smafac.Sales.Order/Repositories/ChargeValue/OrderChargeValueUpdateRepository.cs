using Smafac.Framework.Core.Repositories;
using Smafac.Sales.Order.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Repositories.ChargeValue
{
    class OrderChargeValueUpdateRepository : EntityUpdateRepository<OrderContext, OrderChargeValueEntity>,
                                            IOrderChargeValueUpdateRepository

    {
        public OrderChargeValueUpdateRepository(OrderContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }

        protected override void SetValue(OrderChargeValueEntity entity, OrderChargeValueEntity source)
        {
            entity.Charge = source.Charge;
        }
    }
}
