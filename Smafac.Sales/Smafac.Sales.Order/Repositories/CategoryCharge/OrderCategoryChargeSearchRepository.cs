using Smafac.Framework.Core.Repositories.CategoryAssociation;
using Smafac.Framework.Core.Repositories.CategoryProperty;
using Smafac.Sales.Order.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Repositories.CategoryCharge
{
    class OrderCategoryChargeSearchRepository : CategoryAssociationSearchRepository<OrderContext, OrderCategoryEntity, OrderChargeEntity, OrderCategoryChargeEntity>,
                                                  IOrderCategoryChargeSearchRepository
    {
        public OrderCategoryChargeSearchRepository(IOrderContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }

        public override bool Any(Guid subscriberId, Guid associationId)
        {
            using (var context = ContextProvider.Provide())
            {
                return context.Set<OrderCategoryChargeEntity>().Any(s => s.SubscriberId == subscriberId && s.ChargeId == associationId);
            }
        }

        protected override IEnumerable<Guid> GetAssociationIds(IQueryable<OrderCategoryChargeEntity> binds, Guid entityId)
        {
            return binds.Where(s => s.CategoryId.Equals(entityId)).Select(s => s.ChargeId).ToList();
        }
    }
}
