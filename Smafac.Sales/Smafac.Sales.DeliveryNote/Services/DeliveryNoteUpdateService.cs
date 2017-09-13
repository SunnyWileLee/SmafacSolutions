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
        private readonly IDeliveryNoteUpdateRepository _noteUpdateRepository;
        private readonly IDeliveryNotePropertyValueSetRepository _notePropertyValueSetRepository;

        public DeliveryNoteUpdateService(IDeliveryNoteUpdateRepository noteUpdateRepository,
                                    IDeliveryNotePropertyValueSetRepository notePropertyValueSetRepository)
        {
            _noteUpdateRepository = noteUpdateRepository;
            _notePropertyValueSetRepository = notePropertyValueSetRepository;
        }

        public bool UpdateDeliveryNote(DeliveryNoteModel model)
        {
            var note = Mapper.Map<DeliveryNoteEntity>(model);
            note.SubscriberId = UserContext.Current.SubscriberId;
            var update = _noteUpdateRepository.UpdateEntity(note);

            if (update && model.HasProperties)
            {
                model.Properties.ForEach(property =>
                {
                    property.DeliveryNoteId = note.Id;
                    property.SubscriberId = note.SubscriberId;
                    var value = Mapper.Map<DeliveryNotePropertyValueEntity>(property);
                    update &= _notePropertyValueSetRepository.SetPropertyValue(value);
                });
            }
            return update;
        }
    }
}
