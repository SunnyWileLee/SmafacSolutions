using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Framework.Core.Models;
using Smafac.Framework.Core.Models;
using Smafac.Sales.DeliveryNote.Repositories;
using Smafac.Sales.DeliveryNote.Models;
using Smafac.Sales.DeliveryNote.Domain.CategoryProperty;

namespace Smafac.Sales.DeliveryNote.Domain.Property
{
    class DeliveryNotePropertyProvider : IDeliveryNotePropertyProvider
    {
        private readonly IDeliveryNoteSearchRepository _noteSearchRepository;
        private readonly IDeliveryNoteCategoryPropertyProvider _noteCategoryPropertyProvider;

        public DeliveryNotePropertyProvider(IDeliveryNoteSearchRepository noteSearchRepository,
                                    IDeliveryNoteCategoryPropertyProvider noteCategoryPropertyProvider
                                    )
        {
            _noteSearchRepository = noteSearchRepository;
            _noteCategoryPropertyProvider = noteCategoryPropertyProvider;
        }

        public List<DeliveryNotePropertyModel> Provide(Guid noteId)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var note = _noteSearchRepository.GetEntity(subscriberId, noteId);
            return _noteCategoryPropertyProvider.ProvideAssociations(note.CategoryId);
        }
    }
}
