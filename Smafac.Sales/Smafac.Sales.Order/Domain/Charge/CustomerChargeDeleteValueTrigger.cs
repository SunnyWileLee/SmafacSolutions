using Smafac.Framework.Core.Models;
using Smafac.Sales.Order.Repositories.ChargeValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Domain.Charge
{
    class CustomerChargeDeleteValueTrigger : IOrderChargeDeleteTrigger
    {
        private readonly IOrderChargeValueRepository _orderChargeValueRepository;

        public CustomerChargeDeleteValueTrigger(IOrderChargeValueRepository orderChargeValueRepository)
        {
            _orderChargeValueRepository = orderChargeValueRepository;
        }

        public bool Deleted(OrderChargeEntity charge)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            if (subscriberId != charge.SubscriberId)
            {
                return false;
            }
            return _orderChargeValueRepository.Delete(subscriberId, charge.Id);
        }
    }
}
