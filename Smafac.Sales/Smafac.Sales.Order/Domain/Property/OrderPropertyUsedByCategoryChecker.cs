using Smafac.Framework.Core.Domain.Property;
using Smafac.Sales.Order.Repositories.CategoryProperty;

namespace Smafac.Sales.Order.Domain.Property
{
    class OrderPropertyUsedByCategoryChecker : PropertyUsedByCategoryChecker<OrderCategoryEntity, OrderPropertyEntity>,
                                                IOrderPropertyUsedChecker
    {
        public OrderPropertyUsedByCategoryChecker(IOrderCategoryPropertySearchRepository orderCategoryPropertySearchRepository)
        {
            base.CategoryPropertySearchRepository = orderCategoryPropertySearchRepository;
        }
    }
}
