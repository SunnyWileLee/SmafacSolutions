using Smafac.Framework.Core.Repositories.Property;
using Smafac.Sales.DeliveryNote.Domain;

namespace Smafac.Sales.DeliveryNote.Repositories.ItemProperty
{
    class DeliveryNoteItemPropertyAddRepository : PropertyAddRepository<DeliveryNoteContext, DeliveryNoteItemPropertyEntity>, IDeliveryNoteItemPropertyAddRepository
    {
        public DeliveryNoteItemPropertyAddRepository(IDeliveryNoteContextProvider contextProvider)
        {
            base.ContextProvider  = contextProvider;
        }
    }
}
