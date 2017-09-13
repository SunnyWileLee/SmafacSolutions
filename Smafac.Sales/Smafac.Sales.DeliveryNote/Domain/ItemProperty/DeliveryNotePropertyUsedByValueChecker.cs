using Smafac.Framework.Core.Domain.Property;
using Smafac.Sales.DeliveryNote.Models;
using Smafac.Sales.DeliveryNote.Repositories.ItemPropertyValue;

namespace Smafac.Sales.DeliveryNote.Domain.ItemProperty
{
    class DeliveryNoteItemPropertyUsedByValueChecker : PropertyUsedByValueChecker<DeliveryNoteItemPropertyEntity, DeliveryNoteItemPropertyValueModel>,
                                                IDeliveryNoteItemPropertyUsedChecker
    {
        public DeliveryNoteItemPropertyUsedByValueChecker(IDeliveryNoteItemPropertyValueSearchRepository propertyValueSearchRepository)
        {
            base.PropertyValueSearchRepository = propertyValueSearchRepository;
        }
    }
}
