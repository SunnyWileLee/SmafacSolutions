using Smafac.Framework.Core.Repositories;
using Smafac.Sales.DeliveryNote.Domain;

namespace Smafac.Sales.DeliveryNote.Repositories
{
    class DeliveryNoteUpdateRepository : EntityUpdateRepository<DeliveryNoteContext, DeliveryNoteEntity>,
                                IDeliveryNoteUpdateRepository
    {
        public DeliveryNoteUpdateRepository(DeliveryNoteContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }

        protected override void SetValue(DeliveryNoteEntity entity, DeliveryNoteEntity source)
        {
            entity.Amount = source.Amount;
            entity.DeliveryTime = source.DeliveryTime;
            entity.Memo = source.Memo;
        }
    }
}
