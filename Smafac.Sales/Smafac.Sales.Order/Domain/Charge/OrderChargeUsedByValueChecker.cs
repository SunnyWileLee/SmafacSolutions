using Smafac.Framework.Core.Models;
using Smafac.Sales.Order.Repositories.Charge;
using System;

namespace Smafac.Sales.Order.Domain.Charge
{
    class OrderChargeUsedByValueChecker : IOrderChargeUsedChecker
    {
        private readonly IOrderChargeValueRepository _orderChargeValueRepository;

        public OrderChargeUsedByValueChecker(IOrderChargeValueRepository orderChargeValueRepository)
        {
            _orderChargeValueRepository = orderChargeValueRepository;
        }

        public bool Check(OrderChargeEntity column)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            return _orderChargeValueRepository.Any(subscriberId, column.Id);
        }
    }
}
