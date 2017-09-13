using Smafac.Framework.Core.Models;
using Smafac.Sales.DeliveryNote.Domain.CategoryItemProperty;
using Smafac.Sales.DeliveryNote.Models;
using Smafac.Sales.DeliveryNote.Repositories;
using System;
using System.Collections.Generic;

namespace Smafac.Sales.DeliveryNote.Domain.ItemProperty
{
    class DeliveryNoteItemPropertyProvider : IDeliveryNoteItemPropertyProvider
    {
        private readonly IDeliveryNoteSearchRepository _noteSearchRepository;
        private readonly IDeliveryNoteCategoryItemPropertyProvider _noteCategoryItemPropertyProvider;

        public DeliveryNoteItemPropertyProvider(IDeliveryNoteSearchRepository noteSearchRepository,
                                    IDeliveryNoteCategoryItemPropertyProvider noteCategoryItemPropertyProvider
                                    )
        {
            _noteSearchRepository = noteSearchRepository;
            _noteCategoryItemPropertyProvider = noteCategoryItemPropertyProvider;
        }

        public List<DeliveryNoteItemPropertyModel> Provide(Guid noteId)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var note = _noteSearchRepository.GetEntity(subscriberId, noteId);
            return _noteCategoryItemPropertyProvider.ProvideAssociations(note.CategoryId);
        }
    }
}
