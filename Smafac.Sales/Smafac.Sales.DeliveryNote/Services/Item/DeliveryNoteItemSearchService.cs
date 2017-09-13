using Smafac.Sales.DeliveryNote.Applications.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Sales.DeliveryNote.Models;
using Smafac.Framework.Core.Models;
using AutoMapper;
using Smafac.Sales.DeliveryNote.Repositories.Item;
using Smafac.Sales.DeliveryNote.Repositories.ItemPropertyValue;

namespace Smafac.Sales.DeliveryNote.Services.Item
{
    class DeliveryNoteItemSearchService : IDeliveryNoteItemSearchService
    {
        private readonly IDeliveryNoteItemSearchRepository _itemSearchRepository;
        private readonly IDeliveryNoteItemPropertyValueSearchRepository _itemPropertyValueSearchRepository;

        public DeliveryNoteItemSearchService(IDeliveryNoteItemSearchRepository itemSearchRepository,
                                            IDeliveryNoteItemPropertyValueSearchRepository itemPropertyValueSearchRepository
                                    )
        {
            _itemSearchRepository = itemSearchRepository;
            _itemPropertyValueSearchRepository = itemPropertyValueSearchRepository;
        }

        public DeliveryNoteItemModel GetItem(Guid itemId)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var item = _itemSearchRepository.GetEntity(subscriberId, itemId);
            if (item == null)
            {
                return null;
            }
            var properties = _itemPropertyValueSearchRepository.GetPropertyValues(UserContext.Current.SubscriberId, item.Id);
            var model = Mapper.Map<DeliveryNoteItemModel>(item);
            model.Properties = properties;
            return model;
        }
    }
}
