using AutoMapper;
using Smafac.Framework.Core.Models;
using Smafac.Sales.DeliveryNote.Applications.Item;
using Smafac.Sales.DeliveryNote.Domain;
using Smafac.Sales.DeliveryNote.Models;
using Smafac.Sales.DeliveryNote.Repositories.Item;
using Smafac.Sales.DeliveryNote.Repositories.ItemPropertyValue;

namespace Smafac.Sales.DeliveryNote.Services.Item
{
    class DeliveryNoteItemUpdateService : IDeliveryNoteItemUpdateService
    {
        private readonly IDeliveryNoteItemUpdateRepository _itemUpdateRepository;
        private readonly IDeliveryNoteItemPropertyValueSetRepository _itemPropertyValueSetRepository;

        public DeliveryNoteItemUpdateService(IDeliveryNoteItemUpdateRepository itemUpdateRepository,
                                    IDeliveryNoteItemPropertyValueSetRepository itemPropertyValueSetRepository)
        {
            _itemUpdateRepository = itemUpdateRepository;
            _itemPropertyValueSetRepository = itemPropertyValueSetRepository;
        }

        public bool UpdateDeliveryNoteItem(DeliveryNoteItemModel model)
        {
            var item = Mapper.Map<DeliveryNoteItemEntity>(model);
            item.SubscriberId = UserContext.Current.SubscriberId;
            var update = _itemUpdateRepository.UpdateEntity(item);

            if (update && model.HasProperties)
            {
                model.Properties.ForEach(property =>
                {
                    property.DeliveryNoteItemId = item.Id;
                    property.SubscriberId = item.SubscriberId;
                    var value = Mapper.Map<DeliveryNoteItemPropertyValueEntity>(property);
                    update &= _itemPropertyValueSetRepository.SetPropertyValue(value);
                });
            }
            return update;
        }
    }
}
