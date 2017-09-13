using Smafac.Framework.Core.Services.Property;
using Smafac.Sales.DeliveryNote.Applications.ItemProperty;
using Smafac.Sales.DeliveryNote.Domain;
using Smafac.Sales.DeliveryNote.Domain.ItemProperty;
using Smafac.Sales.DeliveryNote.Models;
using Smafac.Sales.DeliveryNote.Repositories.ItemProperty;
using System;
using System.Collections.Generic;

namespace Smafac.Sales.DeliveryNote.Services.ItemProperty
{
    class DeliveryNoteItemPropertySearchService : PropertySearchService<DeliveryNoteItemPropertyEntity, DeliveryNoteItemPropertyModel>
                                            , IDeliveryNoteItemPropertySearchService
    {
        private readonly IDeliveryNoteItemPropertyProvider _propertyProvider;

        public DeliveryNoteItemPropertySearchService(IDeliveryNoteItemPropertySearchRepository propertySearchRepository,
                                            IDeliveryNoteItemPropertyProvider propertyProvider)
        {
            base.CustomizedColumnSearchRepository = propertySearchRepository;
            _propertyProvider = propertyProvider;
        }

        public override List<DeliveryNoteItemPropertyModel> GetColumns(Guid entityId)
        {
            return _propertyProvider.Provide(entityId);
        }
    }
}
