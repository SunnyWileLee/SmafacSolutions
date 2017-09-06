using Smafac.Framework.Core.Repositories;
using Smafac.Sales.Order.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Sales.Order.Models;
using Smafac.Sales.Order.Repositories.Joiners;

namespace Smafac.Sales.Order.Repositories.Charge
{
    class OrderChargeValueSearchRepository : EntityRepository<OrderContext, OrderChargeValueEntity>,
                                            IOrderChargeValueSearchRepository
    {
        private readonly IOrderChargeValueJoiner _orderChargeValueJoiner;

        public OrderChargeValueSearchRepository(IOrderContextProvider contextProvider,
                                                IOrderChargeValueJoiner orderChargeValueJoiner)
        {
            base.ContextProvider = contextProvider;
            _orderChargeValueJoiner = orderChargeValueJoiner;
        }

        public bool Any(Guid subscriberId, Guid chargeId)
        {
            using (var context = ContextProvider.Provide())
            {
                return context.OrderChargeValues.Any(s => s.SubscriberId == subscriberId && s.ChargeId == chargeId);
            }
        }

        public List<OrderChargeValueModel> GetChargeValues(Guid subscriberId, Guid orderId)
        {
            using (var context = ContextProvider.Provide())
            {
                var values = context.OrderChargeValues.Where(s => s.SubscriberId == subscriberId && s.OrderId == orderId);
                var charges = context.OrderCharges.Where(s => s.SubscriberId == subscriberId);
                var query = _orderChargeValueJoiner.Join(values, charges);
                return query.ToList();
            }
        }

        public IEnumerable<IGrouping<Guid, OrderChargeValueModel>> GetChargeValues(Guid subscriberId, IEnumerable<Guid> orderIds)
        {
            using (var context = ContextProvider.Provide())
            {
                var values = context.OrderChargeValues.Where(s => s.SubscriberId == subscriberId && orderIds.Contains(s.OrderId));
                var charges = context.OrderCharges.Where(s => s.SubscriberId == subscriberId);
                var query = _orderChargeValueJoiner.Join(values, charges);
                return query.ToList().GroupBy(s => s.OrderId);
            }
        }
    }
}
