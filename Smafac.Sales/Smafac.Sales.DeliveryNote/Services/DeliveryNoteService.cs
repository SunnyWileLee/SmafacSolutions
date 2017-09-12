using AutoMapper;
using Newtonsoft.Json;
using Smafac.Framework.Core.Models;
using Smafac.Sales.DeliveryNote.Applications;
using Smafac.Sales.DeliveryNote.Domain;
using Smafac.Sales.DeliveryNote.Models;
using Smafac.Sales.DeliveryNote.Repositories;
using Smafac.Sales.DeliveryNote.Repositories.Property;
using Smafac.Sales.DeliveryNote.Repositories.PropertyValue;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Smafac.Sales.DeliveryNote.Services
{
    class DeliveryNoteService : IDeliveryNoteService
    {
        private readonly IDeliveryNoteRepository _orderRepository;
        private readonly IDeliveryNotePropertyValueSetRepository _orderPropertyValueSetRepository;
        private readonly IDeliveryNotePropertySearchRepository _orderPropertySearchRepository;

        public IDeliveryNoteUpdateService UpdateService { get; set; }

        public DeliveryNoteService(IDeliveryNoteRepository orderRepository,
                            IDeliveryNoteUpdateService updateService,
                            IDeliveryNotePropertyValueSetRepository orderPropertyValueSetRepository,
                            IDeliveryNotePropertySearchRepository orderPropertySearchRepository)
        {
            _orderRepository = orderRepository;
            _orderPropertyValueSetRepository = orderPropertyValueSetRepository;
            _orderPropertySearchRepository = orderPropertySearchRepository;
            UpdateService = updateService;
        }

        public bool AddDeliveryNote(DeliveryNoteModel model)
        {
            var order = Mapper.Map<DeliveryNoteEntity>(model);
            order.SubscriberId = UserContext.Current.SubscriberId;
            if (_orderRepository.AddDeliveryNote(order))
            {
                if (model.HasProperties)
                {
                    if (!AddPropertyValues(order, model.Properties))
                    {
                        var properties = JsonConvert.SerializeObject(model.Properties);
                    }
                }
                return true;
            }
            return false;
        }


        private bool AddPropertyValues(DeliveryNoteEntity order, IEnumerable<DeliveryNotePropertyValueModel> values)
        {
            var properties = Mapper.Map<List<DeliveryNotePropertyValueEntity>>(values);
            properties.ForEach(property =>
            {
                property.DeliveryNoteId = order.Id;
                property.SubscriberId = order.SubscriberId;
            });
            return _orderPropertyValueSetRepository.AddPropertyValues(order.Id, properties);
        }

        public DeliveryNoteModel CreateEmptyDeliveryNote()
        {
            var properties = _orderPropertySearchRepository.GetEntities(UserContext.Current.SubscriberId, s => true);
            var propertyValues = properties.Select(s => s.CreateEmptyValue()).ToList();
            var order = new DeliveryNoteModel
            {
                Properties = Mapper.Map<List<DeliveryNotePropertyValueModel>>(propertyValues)
            };
            return order;
        }

        public bool DeleteDeliveryNote(Guid orderId)
        {
            return _orderRepository.DeleteDeliveryNote(UserContext.Current.SubscriberId, orderId);
        }
    }
}
