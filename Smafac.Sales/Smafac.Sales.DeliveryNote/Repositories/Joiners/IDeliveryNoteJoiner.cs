using Smafac.Sales.DeliveryNote.Domain;
using Smafac.Sales.DeliveryNote.Models;
using System.Linq;

namespace Smafac.Sales.DeliveryNote.Repositories.Joiners
{
    interface IDeliveryNoteJoiner
    {
        IQueryable<DeliveryNoteModel> Join(IQueryable<DeliveryNoteEntity> notes, IQueryable<DeliveryNoteCategoryEntity> categories);
    }
}
