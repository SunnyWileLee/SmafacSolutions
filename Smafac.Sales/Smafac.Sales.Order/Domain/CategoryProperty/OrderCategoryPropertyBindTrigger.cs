using Smafac.Framework.Core.Domain.CategoryProperty;
using Smafac.Sales.Order.Repositories;
using Smafac.Sales.Order.Repositories.PropertyValue;
using System;
using System.Linq.Expressions;

namespace Smafac.Sales.Order.Domain.CategoryProperty
{
    class OrderCategoryPropertyBindTrigger : CategoryPropertyBindTrigger<OrderEntity, OrderCategoryEntity, OrderPropertyEntity, OrderPropertyValueEntity>,
                                            IOrderCategoryPropertyBindTrigger
    {
        public OrderCategoryPropertyBindTrigger(IOrderSearchRepository orderSearchRepository,
                                                IOrderPropertyValueSetRepository orderPropertyValueSetRepository)
        {
            base.EntitySearchRepository = orderSearchRepository;
            base.AssociationValueAddRepository = orderPropertyValueSetRepository;
        }

        protected override void ModifyValue(OrderPropertyValueEntity value, Guid orderId, OrderPropertyEntity property)
        {
            base.ModifyValue(value, orderId, property);
            value.OrderId = orderId;
        }

        protected override Expression<Func<OrderEntity, bool>> CreateEntityPredicate(OrderCategoryEntity category)
        {
            return order => order.CategoryId == category.Id;
        }
    }
}
