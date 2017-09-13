using Smafac.Framework.Core.Services.Property;
using Smafac.Sales.DeliveryNote.Applications.ItemProperty;
using Smafac.Sales.DeliveryNote.Domain;
using Smafac.Sales.DeliveryNote.Models;
using Smafac.Sales.DeliveryNote.Repositories.ItemProperty;

namespace Smafac.Sales.DeliveryNote.Services.ItemProperty
{
    class DeliveryNoteItemPropertyUpdateService : PropertyUpdateService<DeliveryNoteItemPropertyEntity, DeliveryNoteItemPropertyModel>,
                                        IDeliveryNoteItemPropertyUpdateService
    {
        public DeliveryNoteItemPropertyUpdateService(IDeliveryNoteItemPropertySearchRepository propertySearchRepository,
                                          IDeliveryNoteItemPropertyUpdateRepository propertyUpdateRepository)
        {
            base.CustomizedColumnSearchRepository = propertySearchRepository;
            base.CustomizedColumnUpdateRepository = propertyUpdateRepository;
        }
    }
}
