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
        private readonly IDeliveryNoteRepository _noteRepository;
        private readonly IDeliveryNotePropertyValueSetRepository _notePropertyValueSetRepository;
        private readonly IDeliveryNotePropertySearchRepository _notePropertySearchRepository;

        public IDeliveryNoteUpdateService UpdateService { get; set; }

        public DeliveryNoteService(IDeliveryNoteRepository noteRepository,
                            IDeliveryNoteUpdateService updateService,
                            IDeliveryNotePropertyValueSetRepository notePropertyValueSetRepository,
                            IDeliveryNotePropertySearchRepository notePropertySearchRepository)
        {
            _noteRepository = noteRepository;
            _notePropertyValueSetRepository = notePropertyValueSetRepository;
            _notePropertySearchRepository = notePropertySearchRepository;
            UpdateService = updateService;
        }

        public bool AddDeliveryNote(DeliveryNoteModel model)
        {
            var note = Mapper.Map<DeliveryNoteEntity>(model);
            note.SubscriberId = UserContext.Current.SubscriberId;
            if (_noteRepository.AddDeliveryNote(note))
            {
                if (model.HasProperties)
                {
                    if (!AddPropertyValues(note, model.Properties))
                    {
                        var properties = JsonConvert.SerializeObject(model.Properties);
                    }
                }
                return true;
            }
            return false;
        }


        private bool AddPropertyValues(DeliveryNoteEntity note, IEnumerable<DeliveryNotePropertyValueModel> values)
        {
            var properties = Mapper.Map<List<DeliveryNotePropertyValueEntity>>(values);
            properties.ForEach(property =>
            {
                property.DeliveryNoteId = note.Id;
                property.SubscriberId = note.SubscriberId;
            });
            return _notePropertyValueSetRepository.AddPropertyValues(note.Id, properties);
        }

        public DeliveryNoteModel CreateEmptyDeliveryNote()
        {
            var properties = _notePropertySearchRepository.GetEntities(UserContext.Current.SubscriberId, s => true);
            var propertyValues = properties.Select(s => s.CreateEmptyValue()).ToList();
            var note = new DeliveryNoteModel
            {
                Properties = Mapper.Map<List<DeliveryNotePropertyValueModel>>(propertyValues)
            };
            return note;
        }
    }
}
