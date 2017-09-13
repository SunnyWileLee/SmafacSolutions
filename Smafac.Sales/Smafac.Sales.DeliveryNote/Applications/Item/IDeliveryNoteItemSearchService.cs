using Smafac.Sales.DeliveryNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.DeliveryNote.Applications.Item
{
    public interface IDeliveryNoteItemSearchService
    {
        DeliveryNoteItemModel GetItem(Guid itemId);
    }
}
