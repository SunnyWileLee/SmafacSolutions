using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Framework.Core.Services.Property;
using Smafac.Sales.DeliveryNote.Domain;
using Smafac.Sales.DeliveryNote.Models;
using Smafac.Sales.DeliveryNote.Applications.Property;
using Smafac.Sales.DeliveryNote.Repositories.Property;

namespace Smafac.Sales.DeliveryNote.Services.Property
{
    class DeliveryNotePropertyAddService : PropertyAddService<DeliveryNotePropertyEntity, DeliveryNotePropertyModel>, IDeliveryNotePropertyAddService
    {
        public DeliveryNotePropertyAddService(IDeliveryNotePropertyAddRepository propertyAddRepository,
                                        IDeliveryNotePropertySearchRepository propertySearchRepository)
        {
            base.CustomizedColumnAddRepository = propertyAddRepository;
            base.CustomizedColumnSearchRepository = propertySearchRepository;
        }
    }
}
