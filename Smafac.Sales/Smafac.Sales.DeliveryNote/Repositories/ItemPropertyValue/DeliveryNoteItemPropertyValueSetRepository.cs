using Smafac.Framework.Core.Repositories.PropertyValue;
using Smafac.Sales.DeliveryNote.Domain;
using System;
using System.Linq;

namespace Smafac.Sales.DeliveryNote.Repositories.ItemPropertyValue
{
    class DeliveryNoteItemPropertyValueSetRepository : PropertyValueSetRepository<DeliveryNoteContext, DeliveryNoteItemPropertyValueEntity>
                                                , IDeliveryNoteItemPropertyValueSetRepository
    {
        public DeliveryNoteItemPropertyValueSetRepository(IDeliveryNoteContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }

        protected override bool HasSetValue(IQueryable<DeliveryNoteItemPropertyValueEntity> values, Guid entityId)
        {
            return values.Any(s => s.DeliveryNoteItemId.Equals(entityId));
        }

        protected override bool VerifyEntityId(Guid entityId, DeliveryNoteItemPropertyValueEntity value)
        {
            return !entityId.Equals(value.DeliveryNoteItemId);
        }
    }
}
