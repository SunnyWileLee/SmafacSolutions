using Smafac.Framework.Core.Domain.Property;
using Smafac.Sales.Order.Repositories.CategoryProperty;

namespace Smafac.Sales.Order.Domain.Property
{
    class CustomerPropertyDeleteCategoryTrigger : PropertyDeleteCategoryTrigger<OrderCategoryEntity, OrderPropertyEntity, OrderCategoryPropertyEntity>,
        IOrderPropertyDeleteTrigger
    {
        public CustomerPropertyDeleteCategoryTrigger(IOrderCategoryPropertyBindRepository orderCategoryPropertyBindRepository)
        {
            base.CategoryPropertyBindRepository = orderCategoryPropertyBindRepository;
        }
    }
}
