using Smafac.Framework.Core.Repositories;
using Smafac.Sales.DeliveryNote.Domain;

namespace Smafac.Sales.DeliveryNote.Repositories.Item
{
    class DeliveryNoteItemUpdateRepository : EntityUpdateRepository<DeliveryNoteContext, DeliveryNoteItemEntity>,
                                IDeliveryNoteItemUpdateRepository
    {
        public DeliveryNoteItemUpdateRepository(DeliveryNoteContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }

        protected override void SetValue(DeliveryNoteItemEntity entity, DeliveryNoteItemEntity source)
        {
            entity.Quantity = source.Quantity;
            entity.Amount = source.Amount;
        }
    }
}
