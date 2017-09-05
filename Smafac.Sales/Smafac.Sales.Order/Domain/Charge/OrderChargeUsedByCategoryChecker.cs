using Smafac.Framework.Core.Models;
using Smafac.Sales.Order.Repositories.CategoryProperty;
using System;

namespace Smafac.Sales.Order.Domain.Charge
{
    class OrderChargeUsedByCategoryChecker : IOrderChargeUsedChecker
    {
        private readonly IOrderCategoryPropertySearchRepository _orderCategoryPropertySearchRepository;

        public OrderChargeUsedByCategoryChecker(IOrderCategoryPropertySearchRepository orderCategoryPropertySearchRepository)
        {
            _orderCategoryPropertySearchRepository = orderCategoryPropertySearchRepository;
        }

        public bool Check(OrderChargeEntity column)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            return _orderCategoryPropertySearchRepository.Any(subscriberId, column.Id);
        }
    }
}
