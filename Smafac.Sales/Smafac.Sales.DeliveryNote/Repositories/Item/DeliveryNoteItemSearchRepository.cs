using Smafac.Framework.Core.Repositories;
using Smafac.Sales.DeliveryNote.Domain;

namespace Smafac.Sales.DeliveryNote.Repositories.Item
{
    class DeliveryNoteItemSearchRepository : EntitySearchRepository<DeliveryNoteContext, DeliveryNoteItemEntity>, IDeliveryNoteItemSearchRepository
    {
        public DeliveryNoteItemSearchRepository(IDeliveryNoteContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}
