using Smafac.Framework.Core.Domain.Property;
using Smafac.Sales.DeliveryNote.Repositories.ItemPropertyValue;

namespace Smafac.Sales.DeliveryNote.Domain.ItemProperty
{
    class CustomerItemPropertyDeleteValueTrigger : PropertyDeleteValueTrigger<DeliveryNoteItemPropertyEntity, DeliveryNoteItemPropertyValueEntity>,
                                            IDeliveryNoteItemPropertyDeleteTrigger
    {
        public CustomerItemPropertyDeleteValueTrigger(IDeliveryNoteItemPropertyValueDeleteRepository propertyValueDeleteRepository)
        {
            base.PropertyValueDeleteRepository = propertyValueDeleteRepository;
        }
    }
}
