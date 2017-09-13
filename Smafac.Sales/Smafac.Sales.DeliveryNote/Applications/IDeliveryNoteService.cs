using Smafac.Sales.DeliveryNote.Models;
using System;

namespace Smafac.Sales.DeliveryNote.Applications
{
    public interface IDeliveryNoteService
    {
        IDeliveryNoteUpdateService UpdateService { get; set; }
        bool AddDeliveryNote(DeliveryNoteModel model);
        DeliveryNoteModel CreateEmptyDeliveryNote();
    }
}
