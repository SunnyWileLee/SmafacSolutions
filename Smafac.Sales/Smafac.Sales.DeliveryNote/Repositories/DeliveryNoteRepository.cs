using Smafac.Sales.DeliveryNote.Domain;
using System;
using System.Linq;

namespace Smafac.Sales.DeliveryNote.Repositories
{
    class DeliveryNoteRepository : IDeliveryNoteRepository
    {
        private readonly IDeliveryNoteContextProvider _orderContextProvider;

        public DeliveryNoteRepository(IDeliveryNoteContextProvider contextProvider)
        {
            _orderContextProvider = contextProvider;
        }

        public bool AddDeliveryNote(DeliveryNoteEntity order)
        {
            using (var context = _orderContextProvider.Provide())
            {
                context.DeliveryNotes.Add(order);
                return context.SaveChanges() > 0;
            }
        }

        public bool DeleteDeliveryNote(Guid subscriberId, Guid orderId)
        {
            using (var context = _orderContextProvider.Provide())
            {
                var order = context.DeliveryNotes.FirstOrDefault(s => s.SubscriberId == subscriberId && s.Id == orderId);
                if (order == null)
                {
                    return true;
                }
                context.DeliveryNotes.Remove(order);
                return context.SaveChanges() > 0;
            }
        }
    }
}
