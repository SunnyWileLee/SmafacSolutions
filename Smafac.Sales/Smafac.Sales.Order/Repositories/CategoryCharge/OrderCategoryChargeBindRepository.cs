using Smafac.Framework.Core.Repositories.CategoryAssociation;
using Smafac.Sales.Order.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Repositories.CategoryCharge
{
    class OrderCategoryChargeBindRepository : CategoryAssociationBindRepository<OrderContext, OrderCategoryEntity, OrderChargeEntity, OrderCategoryChargeEntity>,
                                                IOrderCategoryChargeBindRepository
    {
        public OrderCategoryChargeBindRepository(IOrderContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }

        public override bool UnbindAssociation(Guid subscriberId, Guid associationId)
        {
            using (var context = ContextProvider.Provide())
            {
                var charges = context.OrderCategoryCharges.Where(s => s.SubscriberId == subscriberId && s.ChargeId == associationId).ToList();
                if (!charges.Any())
                {
                    return true;
                }
                context.OrderCategoryCharges.RemoveRange(charges);
                return context.SaveChanges() > 0;
            }
        }

        protected override OrderCategoryChargeEntity CreateBind(Guid associationId)
        {
            var bind = base.CreateBind(associationId);
            bind.ChargeId = associationId;
            return bind;
        }
    }
}
