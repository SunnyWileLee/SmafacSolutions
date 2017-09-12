using Smafac.Framework.Core.Repositories.CategoryProperty;
using Smafac.Sales.DeliveryNote.Domain;

namespace Smafac.Sales.DeliveryNote.Repositories.CategoryItemProperty
{
    class DeliveryNoteCategoryItemPropertyBindRepository : CategoryPropertyBindRepository<DeliveryNoteContext, DeliveryNoteCategoryEntity, DeliveryNoteItemPropertyEntity, DeliveryNoteCategoryItemPropertyEntity>,
                                                IDeliveryNoteCategoryItemPropertyBindRepository
    {
        public DeliveryNoteCategoryItemPropertyBindRepository(IDeliveryNoteContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}
