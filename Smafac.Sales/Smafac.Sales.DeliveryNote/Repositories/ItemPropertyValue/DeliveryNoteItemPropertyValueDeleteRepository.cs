using Smafac.Framework.Core.Repositories.PropertyValue;
using Smafac.Sales.DeliveryNote.Domain;

namespace Smafac.Sales.DeliveryNote.Repositories.ItemPropertyValue
{
    class DeliveryNoteItemPropertyValueDeleteRepository : PropertyValueDeleteRepository<DeliveryNoteContext, DeliveryNoteItemPropertyValueEntity>,
                                                IDeliveryNoteItemPropertyValueDeleteRepository
    {

        public DeliveryNoteItemPropertyValueDeleteRepository(IDeliveryNoteContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}
