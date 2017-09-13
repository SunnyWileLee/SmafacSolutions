using Smafac.Framework.Core.Applications.Property;
using Smafac.Sales.DeliveryNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.DeliveryNote.Applications.Property
{
    public interface IDeliveryNotePropertyService 
    {
        IDeliveryNotePropertyAddService AddService { get; set; }
        IDeliveryNotePropertyDeleteService DeleteService { get; set; }
        IDeliveryNotePropertySearchService SearchService { get; set; }
        IDeliveryNotePropertyUpdateService UpdateService { get; set; }
    }
}
