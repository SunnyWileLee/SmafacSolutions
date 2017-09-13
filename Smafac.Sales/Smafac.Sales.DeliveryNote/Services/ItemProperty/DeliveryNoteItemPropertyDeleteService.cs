using Smafac.Framework.Core.Services.Property;
using Smafac.Sales.DeliveryNote.Applications.ItemProperty;
using Smafac.Sales.DeliveryNote.Domain;
using Smafac.Sales.DeliveryNote.Domain.ItemProperty;
using Smafac.Sales.DeliveryNote.Models;
using Smafac.Sales.DeliveryNote.Repositories.ItemProperty;
using System.Collections.Generic;

namespace Smafac.Sales.DeliveryNote.Services.ItemProperty
{
    class DeliveryNoteItemPropertyDeleteService : PropertyDeleteService<DeliveryNoteItemPropertyEntity, DeliveryNoteItemPropertyModel>, IDeliveryNoteItemPropertyDeleteService
    {
        public DeliveryNoteItemPropertyDeleteService(IDeliveryNoteItemPropertyDeleteRepository propertyDeleteRepository,
                                           IDeliveryNoteItemPropertySearchRepository propertySearchRepository,
                                           IEnumerable<IDeliveryNoteItemPropertyUsedChecker> propertyUsedCheckers,
                                            IDeliveryNoteItemPropertyDeleteTrigger[] propertyDeleteTriggers)
        {
            base.CustomizedColumnDeleteRepository = propertyDeleteRepository;
            base.CustomizedColumnUsedCheckers = propertyUsedCheckers;
            base.CustomizedColumnSearchRepository = propertySearchRepository;
            base.CustomizedColumnDeleteTriggers = propertyDeleteTriggers;
        }
    }
}
