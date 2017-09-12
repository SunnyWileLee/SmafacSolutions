using Smafac.Framework.Core.Repositories.Property;
using Smafac.Sales.DeliveryNote.Domain;

namespace Smafac.Sales.DeliveryNote.Repositories.ItemProperty
{
    class DeliveryNoteItemPropertyDeleteRepository : PropertyDeleteRepository<DeliveryNoteContext, DeliveryNoteItemPropertyEntity>, IDeliveryNoteItemPropertyDeleteRepository
    {
        public DeliveryNoteItemPropertyDeleteRepository(IDeliveryNoteContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}
