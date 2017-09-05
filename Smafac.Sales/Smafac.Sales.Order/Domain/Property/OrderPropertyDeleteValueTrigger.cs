using Smafac.Framework.Core.Domain.Property;
using Smafac.Sales.Order.Repositories.PropertyValue;

namespace Smafac.Sales.Order.Domain.Property
{
    class CustomerPropertyDeleteValueTrigger : PropertyDeleteValueTrigger<OrderPropertyEntity, OrderPropertyValueEntity>,
                                            IOrderPropertyDeleteTrigger
    {
        public CustomerPropertyDeleteValueTrigger(IOrderPropertyValueDeleteRepository orderPropertyValueDeleteRepository)
        {
            base.PropertyValueDeleteRepository = orderPropertyValueDeleteRepository;
        }
    }
}
