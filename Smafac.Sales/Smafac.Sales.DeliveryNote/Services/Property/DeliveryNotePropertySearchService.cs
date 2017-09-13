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
    class DeliveryNotePropertySearchService : PropertySearchService<DeliveryNotePropertyEntity, DeliveryNotePropertyModel>
                                            , IDeliveryNotePropertySearchService
    {
        private readonly IDeliveryNotePropertyProvider _propertyProvider;

        public DeliveryNotePropertySearchService(IDeliveryNotePropertySearchRepository propertySearchRepository,
                                            IDeliveryNotePropertyProvider propertyProvider)
        {
            base.CustomizedColumnSearchRepository = propertySearchRepository;
            _propertyProvider = propertyProvider;
        }

        public override List<DeliveryNotePropertyModel> GetColumns(Guid entityId)
        {
            return _propertyProvider.Provide(entityId);
        }
    }
}
