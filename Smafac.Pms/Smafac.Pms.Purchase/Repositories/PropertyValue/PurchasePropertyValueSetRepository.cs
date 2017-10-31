using Smafac.Framework.Core.Repositories.PropertyValue;
using Smafac.Pms.Purchase.Domain;
using System;
using System.Linq;

namespace Smafac.Pms.Purchase.Repositories.PropertyValue
{
    class PurchasePropertyValueSetRepository : PropertyValueSetRepository<PurchaseContext, PurchasePropertyValueEntity>
                                                , IPurchasePropertyValueSetRepository
    {
        public PurchasePropertyValueSetRepository(IPurchaseContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }

        protected override bool HasSetValue(IQueryable<PurchasePropertyValueEntity> values, Guid entityId)
        {
            return values.Any(s => s.PurchaseId.Equals(entityId));
        }

        protected override bool VerifyEntityId(Guid entityId, PurchasePropertyValueEntity value)
        {
            return !entityId.Equals(value.PurchaseId);
        }
    }
}
