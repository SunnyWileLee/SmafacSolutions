using Smafac.Sales.DeliveryNote.Domain;
using System;

namespace Smafac.Sales.DeliveryNote.Repositories.Item
{
    interface IDeliveryNoteItemRepository
    {
        bool AddDeliveryNoteItem(DeliveryNoteItemEntity item);
        bool DeleteDeliveryNoteItem(Guid subscriberId, Guid itemId);
    }
}
