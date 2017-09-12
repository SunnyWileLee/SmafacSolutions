using Smafac.Framework.Core.Domain.Property;
using Smafac.Sales.DeliveryNote.Models;
using Smafac.Sales.DeliveryNote.Repositories.PropertyValue;

namespace Smafac.Sales.DeliveryNote.Domain.Property
{
    class DeliveryNotePropertyUsedByValueChecker : PropertyUsedByValueChecker<DeliveryNotePropertyEntity, DeliveryNotePropertyValueModel>,
                                                IDeliveryNotePropertyUsedChecker
    {
        public DeliveryNotePropertyUsedByValueChecker(IDeliveryNotePropertyValueSearchRepository propertyValueSearchRepository)
        {
            base.PropertyValueSearchRepository = propertyValueSearchRepository;
        }
    }
}
