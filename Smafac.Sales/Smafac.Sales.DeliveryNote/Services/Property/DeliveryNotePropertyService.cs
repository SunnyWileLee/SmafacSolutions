using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Framework.Core.Applications.Property;
using Smafac.Sales.DeliveryNote.Applications.Property;
using Smafac.Sales.DeliveryNote.Models;

namespace Smafac.Sales.DeliveryNote.Services.Property
{
    class DeliveryNotePropertyService : IDeliveryNotePropertyService
    {
        public DeliveryNotePropertyService(IDeliveryNotePropertyAddService propertyAddService,
            IDeliveryNotePropertyDeleteService propertyDeleteService,
            IDeliveryNotePropertySearchService propertySearchService,
            IDeliveryNotePropertyUpdateService propertyUpdateService)
        {
            AddService = propertyAddService;
            DeleteService = propertyDeleteService;
            SearchService = propertySearchService;
            UpdateService = propertyUpdateService;
        }

        public IDeliveryNotePropertyAddService AddService { get; set; }
        public IDeliveryNotePropertyDeleteService DeleteService { get; set; }
        public IDeliveryNotePropertySearchService SearchService { get; set; }
        public IDeliveryNotePropertyUpdateService UpdateService { get; set; }
    }
}
