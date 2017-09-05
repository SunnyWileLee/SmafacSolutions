using Smafac.Framework.Core.Repositories.PropertyValue;
using Smafac.Sales.Order.Domain;
using System;
using System.Linq;

namespace Smafac.Sales.Order.Repositories.PropertyValue
{
    class OrderPropertyValueSetRepository : PropertyValueSetRepository<OrderContext, OrderPropertyValueEntity>
                                                , IOrderPropertyValueSetRepository
    {
        public OrderPropertyValueSetRepository(IOrderContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }

        protected override bool HasSetValue(IQueryable<OrderPropertyValueEntity> values, Guid entityId)
        {
            return values.Any(s => s.OrderId.Equals(entityId));
        }

        protected override bool VerifyEntityId(Guid entityId, OrderPropertyValueEntity value)
        {
            return !entityId.Equals(value.OrderId);
        }
    }
}
