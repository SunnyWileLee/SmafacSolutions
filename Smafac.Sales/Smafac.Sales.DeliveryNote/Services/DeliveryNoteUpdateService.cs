using AutoMapper;
using Smafac.Framework.Core.Models;
using Smafac.Sales.DeliveryNote.Applications;
using Smafac.Sales.DeliveryNote.Domain;
using Smafac.Sales.DeliveryNote.Models;
using Smafac.Sales.DeliveryNote.Repositories;
using Smafac.Sales.DeliveryNote.Repositories.PropertyValue;

namespace Smafac.Sales.DeliveryNote.Services
{
    class DeliveryNoteUpdateService : IDeliveryNoteUpdateService
    {
        private readonly IDeliveryNoteUpdateRepository _orderUpdateRepository;
        private readonly IDeliveryNotePropertyValueSetRepository _orderPropertyValueSetRepository;

        public DeliveryNoteUpdateService(IDeliveryNoteUpdateRepository orderUpdateRepository,
                                    IDeliveryNotePropertyValueSetRepository orderPropertyValueSetRepository)
        {
            _orderUpdateRepository = orderUpdateRepository;
            _orderPropertyValueSetRepository = orderPropertyValueSetRepository;
        }

        public bool UpdateDeliveryNote(DeliveryNoteModel model)
        {
            var order = Mapper.Map<DeliveryNoteEntity>(model);
            order.SubscriberId = UserContext.Current.SubscriberId;
            var update = _orderUpdateRepository.UpdateEntity(order);

            if (update && model.HasProperties)
            {
                model.Properties.ForEach(property =>
                {
                    property.DeliveryNoteId = order.Id;
                    property.SubscriberId = order.SubscriberId;
                    var value = Mapper.Map<DeliveryNotePropertyValueEntity>(property);
                    update &= _orderPropertyValueSetRepository.SetPropertyValue(value);
                });
            }
            return update;
        }
    }
}
