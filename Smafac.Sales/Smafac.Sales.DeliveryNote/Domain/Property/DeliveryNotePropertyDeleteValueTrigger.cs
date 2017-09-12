using Smafac.Framework.Core.Domain.Property;
using Smafac.Sales.DeliveryNote.Repositories.PropertyValue;

namespace Smafac.Sales.DeliveryNote.Domain.Property
{
    class CustomerPropertyDeleteValueTrigger : PropertyDeleteValueTrigger<DeliveryNotePropertyEntity, DeliveryNotePropertyValueEntity>,
                                            IDeliveryNotePropertyDeleteTrigger
    {
        public CustomerPropertyDeleteValueTrigger(IDeliveryNotePropertyValueDeleteRepository propertyValueDeleteRepository)
        {
            base.PropertyValueDeleteRepository = propertyValueDeleteRepository;
        }
    }
}
