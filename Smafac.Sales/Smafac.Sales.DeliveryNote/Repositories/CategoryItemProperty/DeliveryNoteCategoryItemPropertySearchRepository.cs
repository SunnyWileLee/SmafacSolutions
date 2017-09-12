using Smafac.Framework.Core.Repositories.CategoryProperty;
using Smafac.Sales.DeliveryNote.Domain;

namespace Smafac.Sales.DeliveryNote.Repositories.CategoryItemProperty
{
    class DeliveryNoteCategoryItemPropertySearchRepository : CategoryPropertySearchRepository<DeliveryNoteContext, DeliveryNoteCategoryEntity, DeliveryNoteItemPropertyEntity, DeliveryNoteCategoryItemPropertyEntity>,
                                                  IDeliveryNoteCategoryItemPropertySearchRepository
    {
        public DeliveryNoteCategoryItemPropertySearchRepository(IDeliveryNoteContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}
