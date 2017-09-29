using Smafac.Framework.Core.Models;
using Smafac.Sales.DeliveryNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.DeliveryNote.Domain.ItemProperty
{
    interface IDeliveryNoteItemPropertyProvider
    {
        List<DeliveryNoteItemPropertyModel> Provide(Guid deliveryNoteId);
    }
}
