using Smafac.Framework.Core.Domain.CategoryProperty;
using Smafac.Sales.DeliveryNote.Repositories;
using Smafac.Sales.DeliveryNote.Repositories.PropertyValue;
using System;
using System.Linq.Expressions;

namespace Smafac.Sales.DeliveryNote.Domain.CategoryProperty
{
    class DeliveryNoteCategoryPropertyBindTrigger : CategoryPropertyBindTrigger<DeliveryNoteEntity, DeliveryNoteCategoryEntity, DeliveryNotePropertyEntity, DeliveryNotePropertyValueEntity>,
                                            IDeliveryNoteCategoryPropertyBindTrigger
    {
        public DeliveryNoteCategoryPropertyBindTrigger(IDeliveryNoteSearchRepository noteSearchRepository,
                                                IDeliveryNotePropertyValueSetRepository notePropertyValueSetRepository)
        {
            base.EntitySearchRepository = noteSearchRepository;
            base.AssociationValueAddRepository = notePropertyValueSetRepository;
        }

        protected override void ModifyValue(DeliveryNotePropertyValueEntity value, Guid noteId, DeliveryNotePropertyEntity property)
        {
            base.ModifyValue(value, noteId, property);
            value.DeliveryNoteId = noteId;
        }

        protected override Expression<Func<DeliveryNoteEntity, bool>> CreateEntityPredicate(DeliveryNoteCategoryEntity category)
        {
            return note => note.CategoryId == category.Id;
        }
    }
}
