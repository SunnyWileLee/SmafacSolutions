using Smafac.Framework.Core.Repositories.PropertyValue;
using Smafac.Sales.Order.Domain;

namespace Smafac.Sales.Order.Repositories.PropertyValue
{
    class OrderPropertyValueDeleteRepository : PropertyValueDeleteRepository<OrderContext, OrderPropertyValueEntity>,
                                                IOrderPropertyValueDeleteRepository
    {

        public OrderPropertyValueDeleteRepository(IOrderContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}
