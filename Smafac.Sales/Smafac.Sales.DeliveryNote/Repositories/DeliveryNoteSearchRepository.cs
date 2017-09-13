using System;
using Smafac.Framework.Core.Repositories;
using Smafac.Sales.DeliveryNote.Domain;
using Smafac.Sales.DeliveryNote.Models;
using Smafac.Sales.DeliveryNote.Repositories.Joiners;
using System.Linq;

namespace Smafac.Sales.DeliveryNote.Repositories
{
    class DeliveryNoteSearchRepository : EntitySearchRepository<DeliveryNoteContext, DeliveryNoteEntity>, IDeliveryNoteSearchRepository
    {
        private readonly IDeliveryNoteJoiner _joiner;

        public DeliveryNoteSearchRepository(IDeliveryNoteContextProvider contextProvider,
                                            IDeliveryNoteJoiner joiner)
        {
            base.ContextProvider = contextProvider;
            _joiner = joiner;
        }

        public DeliveryNoteModel GetDeliveryNote(Guid subscriberId, Guid id)
        {
            using (var context = base.ContextProvider.Provide())
            {
                var notes = context.DeliveryNotes.Where(s => s.SubscriberId == subscriberId && s.Id == id);
                var categories = context.DeliveryNoteCategories;
                var query = _joiner.Join(notes, categories).FirstOrDefault();
                return query;
            }
        }
    }
}
