using Smafac.Framework.Core.Domain.CategoryAssociation;

namespace Smafac.Sales.Order.Domain.CategoryCharge
{
    interface IOrderCategoryChargeBindTrigger: ICategoryAssociationBindTrigger<OrderCategoryEntity, OrderChargeEntity>
    {
    }
}
