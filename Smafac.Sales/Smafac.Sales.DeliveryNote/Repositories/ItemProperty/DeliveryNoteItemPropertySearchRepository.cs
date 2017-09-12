using Smafac.Framework.Core.Repositories.Property;
using Smafac.Sales.DeliveryNote.Domain;

namespace Smafac.Sales.DeliveryNote.Repositories.ItemProperty
{
    class DeliveryNoteItemPropertySearchRepository : PropertySearchRepository<DeliveryNoteContext, DeliveryNoteItemPropertyEntity>, IDeliveryNoteItemPropertySearchRepository
    {
        public DeliveryNoteItemPropertySearchRepository(IDeliveryNoteContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}
