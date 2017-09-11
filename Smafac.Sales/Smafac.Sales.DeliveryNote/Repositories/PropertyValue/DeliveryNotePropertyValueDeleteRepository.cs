using Smafac.Framework.Core.Repositories.PropertyValue;
using Smafac.Sales.DeliveryNote.Domain;

namespace Smafac.Sales.DeliveryNote.Repositories.PropertyValue
{
    class DeliveryNotePropertyValueDeleteRepository : PropertyValueDeleteRepository<DeliveryNoteContext, DeliveryNotePropertyValueEntity>,
                                                IDeliveryNotePropertyValueDeleteRepository
    {

        public DeliveryNotePropertyValueDeleteRepository(IDeliveryNoteContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}
