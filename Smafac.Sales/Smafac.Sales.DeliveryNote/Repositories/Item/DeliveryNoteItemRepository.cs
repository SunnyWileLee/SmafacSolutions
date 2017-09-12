using Smafac.Sales.DeliveryNote.Domain;
using System;
using System.Linq;

namespace Smafac.Sales.DeliveryNote.Repositories.Item
{
    class DeliveryNoteItemRepository : IDeliveryNoteItemRepository
    {
        private readonly IDeliveryNoteContextProvider _contextProvider;

        public DeliveryNoteItemRepository(IDeliveryNoteContextProvider contextProvider)
        {
            _contextProvider = contextProvider;
        }

        public bool AddDeliveryNoteItem(DeliveryNoteItemEntity order)
        {
            using (var context = _contextProvider.Provide())
            {
                context.DeliveryNoteItems.Add(order);
                return context.SaveChanges() > 0;
            }
        }

        public bool DeleteDeliveryNoteItem(Guid subscriberId, Guid orderId)
        {
            using (var context = _contextProvider.Provide())
            {
                var order = context.DeliveryNoteItems.FirstOrDefault(s => s.SubscriberId == subscriberId && s.Id == orderId);
                if (order == null)
                {
                    return true;
                }
                context.DeliveryNoteItems.Remove(order);
                return context.SaveChanges() > 0;
            }
        }
    }
}
