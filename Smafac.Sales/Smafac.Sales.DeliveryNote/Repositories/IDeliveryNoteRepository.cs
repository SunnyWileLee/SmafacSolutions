using Smafac.Sales.DeliveryNote.Domain;
using Smafac.Sales.DeliveryNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.DeliveryNote.Repositories
{
    interface IDeliveryNoteRepository
    {
        bool AddDeliveryNote(DeliveryNoteEntity note);
        bool DeleteDeliveryNote(Guid subscriberId, Guid orderId);
    }
}
