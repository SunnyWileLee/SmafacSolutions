using Smafac.Framework.Core.Repositories.PropertyValue;
using Smafac.Sales.DeliveryNote.Domain;
using System;
using System.Linq;

namespace Smafac.Sales.DeliveryNote.Repositories.PropertyValue
{
    class DeliveryNotePropertyValueSetRepository : PropertyValueSetRepository<DeliveryNoteContext, DeliveryNotePropertyValueEntity>
                                                , IDeliveryNotePropertyValueSetRepository
    {
        public DeliveryNotePropertyValueSetRepository(IDeliveryNoteContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }

        protected override bool HasSetValue(IQueryable<DeliveryNotePropertyValueEntity> values, Guid entityId)
        {
            return values.Any(s => s.DeliveryNoteId.Equals(entityId));
        }

        protected override bool VerifyEntityId(Guid entityId, DeliveryNotePropertyValueEntity value)
        {
            return !entityId.Equals(value.DeliveryNoteId);
        }
    }
}
