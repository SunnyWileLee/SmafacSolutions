using Smafac.Framework.Core.Repositories;
using Smafac.Sales.DeliveryNote.Domain;

namespace Smafac.Sales.DeliveryNote.Repositories
{
    class DeliveryNoteSearchRepository : EntitySearchRepository<DeliveryNoteContext, DeliveryNoteEntity>, IDeliveryNoteSearchRepository
    {
        public DeliveryNoteSearchRepository(IDeliveryNoteContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}
