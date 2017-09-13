using Smafac.Sales.DeliveryNote.Applications.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Sales.DeliveryNote.Models;
using Smafac.Sales.DeliveryNote.Repositories.ItemProperty;
using Smafac.Sales.DeliveryNote.Repositories.ItemPropertyValue;
using Smafac.Sales.DeliveryNote.Repositories.Item;
using Smafac.Framework.Core.Models;
using Smafac.Sales.DeliveryNote.Domain;
using AutoMapper;
using Newtonsoft.Json;

namespace Smafac.Sales.DeliveryNote.Services.Item
{
    class DeliveryNoteItemService : IDeliveryNoteItemService
    {
        private readonly IDeliveryNoteItemRepository _itemRepository;
        private readonly IDeliveryNoteItemPropertyValueSetRepository _itemPropertyValueSetRepository;
        private readonly IDeliveryNoteItemPropertySearchRepository _itemPropertySearchRepository;

        public DeliveryNoteItemService(IDeliveryNoteItemRepository itemRepository,
                            IDeliveryNoteItemPropertyValueSetRepository itemPropertyValueSetRepository,
                            IDeliveryNoteItemPropertySearchRepository itemPropertySearchRepository)
        {
            _itemRepository = itemRepository;
            _itemPropertyValueSetRepository = itemPropertyValueSetRepository;
            _itemPropertySearchRepository = itemPropertySearchRepository;
        }

        public bool AddDeliveryNoteItem(DeliveryNoteItemModel model)
        {
            var item = Mapper.Map<DeliveryNoteItemEntity>(model);
            item.SubscriberId = UserContext.Current.SubscriberId;
            if (_itemRepository.AddDeliveryNoteItem(item))
            {
                if (model.HasProperties)
                {
                    if (!AddPropertyValues(item, model.Properties))
                    {
                        var properties = JsonConvert.SerializeObject(model.Properties);
                    }
                }
                return true;
            }
            return false;
        }


        private bool AddPropertyValues(DeliveryNoteItemEntity item, IEnumerable<DeliveryNoteItemPropertyValueModel> values)
        {
            var properties = Mapper.Map<List<DeliveryNoteItemPropertyValueEntity>>(values);
            properties.ForEach(property =>
            {
                property.DeliveryNoteItemId = item.Id;
                property.SubscriberId = item.SubscriberId;
            });
            return _itemPropertyValueSetRepository.AddPropertyValues(item.Id, properties);
        }
    }
}
