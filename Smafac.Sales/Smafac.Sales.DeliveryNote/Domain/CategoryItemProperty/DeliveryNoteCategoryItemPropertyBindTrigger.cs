using Smafac.Framework.Core.Domain.CategoryProperty;
using Smafac.Sales.DeliveryNote.Repositories;
using Smafac.Sales.DeliveryNote.Repositories.ItemPropertyValue;
using System;
using System.Linq.Expressions;

namespace Smafac.Sales.DeliveryNote.Domain.CategoryItemProperty
{
    class DeliveryNoteCategoryItemPropertyBindTrigger : CategoryPropertyBindTrigger<DeliveryNoteEntity, DeliveryNoteCategoryEntity, DeliveryNoteItemPropertyEntity, DeliveryNoteItemPropertyValueEntity>,
                                            IDeliveryNoteCategoryItemPropertyBindTrigger
    {
        public DeliveryNoteCategoryItemPropertyBindTrigger(IDeliveryNoteSearchRepository noteItemSearchRepository,
                                                IDeliveryNoteItemPropertyValueSetRepository noteItemItemPropertyValueSetRepository)
        {
            base.EntitySearchRepository = noteItemSearchRepository;
            base.AssociationValueAddRepository = noteItemItemPropertyValueSetRepository;
        }

        protected override void ModifyValue(DeliveryNoteItemPropertyValueEntity value, Guid noteItemId, DeliveryNoteItemPropertyEntity property)
        {
            base.ModifyValue(value, noteItemId, property);
            value.DeliveryNoteItemId = noteItemId;
        }

        protected override Expression<Func<DeliveryNoteEntity, bool>> CreateEntityPredicate(DeliveryNoteCategoryEntity category)
        {
            return noteItem => noteItem.CategoryId == category.Id;
        }
    }
}
