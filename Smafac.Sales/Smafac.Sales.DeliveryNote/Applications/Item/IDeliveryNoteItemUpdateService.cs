using Smafac.Sales.DeliveryNote.Models;

namespace Smafac.Sales.DeliveryNote.Applications.Item
{
    public interface IDeliveryNoteItemUpdateService
    {
        bool UpdateDeliveryNoteItem(DeliveryNoteItemModel model);
    }
}
