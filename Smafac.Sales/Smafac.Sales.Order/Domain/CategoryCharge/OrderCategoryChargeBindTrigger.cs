using Smafac.Framework.Core.Domain.CategoryAssociation;
using Smafac.Sales.Order.Repositories;
using Smafac.Sales.Order.Repositories.Charge;
using Smafac.Sales.Order.Repositories.ChargeValue;
using System;
using System.Linq.Expressions;

namespace Smafac.Sales.Order.Domain.CategoryCharge
{
    class OrderCategoryChargeBindTrigger : CategoryAssociationBindTrigger<OrderEntity, OrderCategoryEntity, OrderChargeEntity, OrderChargeValueEntity>,
                                            IOrderCategoryChargeBindTrigger
    {
        public OrderCategoryChargeBindTrigger(IOrderSearchRepository orderSearchRepository,
                                                IOrderChargeValueRepository orderChargeValueRepository)
        {
            base.EntitySearchRepository = orderSearchRepository;
            base.AssociationValueAddRepository = orderChargeValueRepository;
        }

        protected override Expression<Func<OrderEntity, bool>> CreateEntityPredicate(OrderCategoryEntity category)
        {
            return order => order.CategoryId == category.Id;
        }

        protected override void ModifyValue(OrderChargeValueEntity value, Guid orderId, OrderChargeEntity charge)
        {
            base.ModifyValue(value, orderId, charge);
            value.OrderId = orderId;
            value.ChargeId = charge.Id;
            value.Charge = 0;
        }
    }
}
