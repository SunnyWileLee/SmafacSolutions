using Smafac.Framework.Core.Domain.Property;
using Smafac.Sales.DeliveryNote.Repositories.CategoryItemProperty;

namespace Smafac.Sales.DeliveryNote.Domain.ItemProperty
{
    class DeliveryNoteItemPropertyUsedByCategoryChecker : PropertyUsedByCategoryChecker<DeliveryNoteCategoryEntity, DeliveryNoteItemPropertyEntity>,
                                                IDeliveryNoteItemPropertyUsedChecker
    {
        public DeliveryNoteItemPropertyUsedByCategoryChecker(IDeliveryNoteCategoryItemPropertySearchRepository categoryPropertySearchRepository)
        {
            base.CategoryPropertySearchRepository = categoryPropertySearchRepository;
        }
    }
}
