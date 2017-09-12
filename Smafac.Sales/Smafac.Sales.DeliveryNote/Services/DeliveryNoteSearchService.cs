using AutoMapper;
using Smafac.Framework.Core.Models;
using Smafac.Sales.DeliveryNote.Applications;
using Smafac.Sales.DeliveryNote.Domain.Pages;
using Smafac.Sales.DeliveryNote.Models;
using Smafac.Sales.DeliveryNote.Repositories;
using Smafac.Sales.DeliveryNote.Repositories.PropertyValue;
using System;
using Smafac.Framework.Models;

namespace Smafac.Sales.DeliveryNote.Services
{
    class DeliveryNoteSearchService : IDeliveryNoteSearchService
    {
        private readonly IDeliveryNoteSearchRepository _noteSearchRepository;
        private readonly IDeliveryNotePropertyValueSearchRepository _notePropertyValueSearchRepository;
        private readonly IDeliveryNotePageQueryer _notePageQueryer;

        public DeliveryNoteSearchService(IDeliveryNoteSearchRepository noteSearchRepository,
                                    IDeliveryNotePropertyValueSearchRepository notePropertyValueSearchRepository,
                                    IDeliveryNotePageQueryer notePageQueryer
                                    )
        {
            _noteSearchRepository = noteSearchRepository;
            _notePropertyValueSearchRepository = notePropertyValueSearchRepository;
            _notePageQueryer = notePageQueryer;
        }

        public DeliveryNoteModel GetDeliveryNote(Guid noteId)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var note = _noteSearchRepository.GetEntity(subscriberId, noteId);
            var properties = _notePropertyValueSearchRepository.GetPropertyValues(subscriberId, noteId);
            var model = Mapper.Map<DeliveryNoteModel>(note);
            model.Properties = properties;
            return model;
        }

        public DeliveryNoteDetailModel GetDeliveryNoteDetail(Guid noteId)
        {
            var note = this.GetDeliveryNote(noteId);
            return new DeliveryNoteDetailModel { DeliveryNote = note };
        }

        public PageModel<DeliveryNoteModel> GetDeliveryNotePage(DeliveryNotePageQueryModel query)
        {
            return _notePageQueryer.Query(query);
        }
    }
}
