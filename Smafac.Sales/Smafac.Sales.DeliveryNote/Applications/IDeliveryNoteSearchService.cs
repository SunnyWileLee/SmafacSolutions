using Smafac.Framework.Models;
using Smafac.Sales.DeliveryNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.DeliveryNote.Applications
{
    public interface IDeliveryNoteSearchService
    {
        PageModel<DeliveryNoteModel> GetDeliveryNotePage(DeliveryNotePageQueryModel model);
        DeliveryNoteModel GetDeliveryNote(Guid noteId);
        DeliveryNoteDetailModel GetDeliveryNoteDetail(Guid noteId);
    }
}
