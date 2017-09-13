using Smafac.Sales.DeliveryNote.Models;
using System;

namespace Smafac.Sales.DeliveryNote.Applications.Item
{
    public interface IDeliveryNoteItemService
    {
        bool AddDeliveryNoteItem(DeliveryNoteItemModel model);
    }
}
