using Smafac.Framework.Core.Services.Property;
using Smafac.Sales.DeliveryNote.Applications.Property;
using Smafac.Sales.DeliveryNote.Domain;
using Smafac.Sales.DeliveryNote.Domain.Property;
using Smafac.Sales.DeliveryNote.Models;
using Smafac.Sales.DeliveryNote.Repositories.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.DeliveryNote.Services.Property
{
    class DeliveryNotePropertyDeleteService : PropertyDeleteService<DeliveryNotePropertyEntity, DeliveryNotePropertyModel>, IDeliveryNotePropertyDeleteService
    {
        public DeliveryNotePropertyDeleteService(IDeliveryNotePropertyDeleteRepository propertyDeleteRepository,
                                           IDeliveryNotePropertySearchRepository propertySearchRepository,
                                           IEnumerable<IDeliveryNotePropertyUsedChecker> propertyUsedCheckers,
                                            IDeliveryNotePropertyDeleteTrigger[] propertyDeleteTriggers)
        {
            base.CustomizedColumnDeleteRepository = propertyDeleteRepository;
            base.CustomizedColumnUsedCheckers = propertyUsedCheckers;
            base.CustomizedColumnSearchRepository = propertySearchRepository;
            base.CustomizedColumnDeleteTriggers = propertyDeleteTriggers;
        }
    }
}
