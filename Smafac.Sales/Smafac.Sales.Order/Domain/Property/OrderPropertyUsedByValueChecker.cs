using Smafac.Framework.Core.Domain.Property;
using Smafac.Sales.Order.Models;
using Smafac.Sales.Order.Repositories.PropertyValue;

namespace Smafac.Sales.Order.Domain.Property
{
    class OrderPropertyUsedByValueChecker : PropertyUsedByValueChecker<OrderPropertyEntity, OrderPropertyValueModel>,
                                                IOrderPropertyUsedChecker
    {
        public OrderPropertyUsedByValueChecker(IOrderPropertyValueSearchRepository orderPropertyValueSearchRepository)
        {
            base.PropertyValueSearchRepository = orderPropertyValueSearchRepository;
        }
    }
}
