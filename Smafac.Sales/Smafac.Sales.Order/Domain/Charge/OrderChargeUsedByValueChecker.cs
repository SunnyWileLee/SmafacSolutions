using Smafac.Framework.Core.Models;
using Smafac.Sales.Order.Repositories.ChargeValue;

namespace Smafac.Sales.Order.Domain.Charge
{
    class OrderChargeUsedByValueChecker : IOrderChargeUsedChecker
    {
        private readonly IOrderChargeValueSearchRepository _orderChargeValueSearchRepository;

        public OrderChargeUsedByValueChecker(IOrderChargeValueSearchRepository orderChargeValueSearchRepository)
        {
            _orderChargeValueSearchRepository = orderChargeValueSearchRepository;
        }

        public bool Check(OrderChargeEntity column)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            return _orderChargeValueSearchRepository.Any(subscriberId, column.Id);
        }
    }
}
