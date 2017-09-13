using Smafac.Framework.Core.Services.Property;
using Smafac.Sales.DeliveryNote.Applications.Property;
using Smafac.Sales.DeliveryNote.Domain;
using Smafac.Sales.DeliveryNote.Models;
using Smafac.Sales.DeliveryNote.Repositories.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.DeliveryNote.Services.Property
{
    class DeliveryNotePropertyUpdateService : PropertyUpdateService<DeliveryNotePropertyEntity, DeliveryNotePropertyModel>,
                                        IDeliveryNotePropertyUpdateService
    {
        public DeliveryNotePropertyUpdateService(IDeliveryNotePropertySearchRepository propertySearchRepository,
                                          IDeliveryNotePropertyUpdateRepository propertyUpdateRepository)
        {
            base.CustomizedColumnSearchRepository = propertySearchRepository;
            base.CustomizedColumnUpdateRepository = propertyUpdateRepository;
        }
    }
}
