using Smafac.Framework.Core.Models;
using Smafac.Sales.Order.Repositories.CategoryCharge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Domain.Charge
{
    class CustomerChargeDeleteCategoryTrigger : IOrderChargeDeleteTrigger
    {
        private readonly IOrderCategoryChargeBindRepository _orderCategoryChargeBindRepository;

        public CustomerChargeDeleteCategoryTrigger(IOrderCategoryChargeBindRepository orderCategoryChargeBindRepository)
        {
            _orderCategoryChargeBindRepository = orderCategoryChargeBindRepository;
        }

        public bool Deleted(OrderChargeEntity entity)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            if (subscriberId != entity.SubscriberId)
            {
                return false;
            }
            return _orderCategoryChargeBindRepository.UnbindAssociation(subscriberId, entity.Id);
        }
    }
}
