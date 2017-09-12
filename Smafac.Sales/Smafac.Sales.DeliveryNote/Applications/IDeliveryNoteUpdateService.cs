using Smafac.Sales.DeliveryNote.Models;

namespace Smafac.Sales.DeliveryNote.Applications
{
    public interface IDeliveryNoteUpdateService
    {
        bool UpdateDeliveryNote(DeliveryNoteModel model);
    }
}
