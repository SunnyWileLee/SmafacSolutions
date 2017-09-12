using Smafac.Framework.Core.Domain.Property;
using Smafac.Sales.DeliveryNote.Repositories.CategoryProperty;

namespace Smafac.Sales.DeliveryNote.Domain.Property
{
    class DeliveryNotePropertyUsedByCategoryChecker : PropertyUsedByCategoryChecker<DeliveryNoteCategoryEntity, DeliveryNotePropertyEntity>,
                                                IDeliveryNotePropertyUsedChecker
    {
        public DeliveryNotePropertyUsedByCategoryChecker(IDeliveryNoteCategoryPropertySearchRepository categoryPropertySearchRepository)
        {
            base.CategoryPropertySearchRepository = categoryPropertySearchRepository;
        }
    }
}
