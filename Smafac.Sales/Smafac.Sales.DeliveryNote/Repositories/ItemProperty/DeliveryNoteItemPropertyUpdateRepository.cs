using Smafac.Framework.Core.Repositories.Property;
using Smafac.Sales.DeliveryNote.Domain;

namespace Smafac.Sales.DeliveryNote.Repositories.ItemProperty
{
    class DeliveryNoteItemPropertyUpdateRepository : PropertyUpdateRepository<DeliveryNoteContext, DeliveryNoteItemPropertyEntity>, IDeliveryNoteItemPropertyUpdateRepository
    {
        public DeliveryNoteItemPropertyUpdateRepository(IDeliveryNoteContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}
