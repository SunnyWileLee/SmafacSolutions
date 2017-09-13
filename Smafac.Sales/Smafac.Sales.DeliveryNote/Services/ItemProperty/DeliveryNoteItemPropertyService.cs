using Smafac.Sales.DeliveryNote.Applications.ItemProperty;

namespace Smafac.Sales.DeliveryNote.Services.ItemProperty
{
    class DeliveryNoteItemPropertyService : IDeliveryNoteItemPropertyService
    {
        public DeliveryNoteItemPropertyService(IDeliveryNoteItemPropertyAddService propertyAddService,
            IDeliveryNoteItemPropertyDeleteService propertyDeleteService,
            IDeliveryNoteItemPropertySearchService propertySearchService,
            IDeliveryNoteItemPropertyUpdateService propertyUpdateService)
        {
            AddService = propertyAddService;
            DeleteService = propertyDeleteService;
            SearchService = propertySearchService;
            UpdateService = propertyUpdateService;
        }

        public IDeliveryNoteItemPropertyAddService AddService { get; set; }
        public IDeliveryNoteItemPropertyDeleteService DeleteService { get; set; }
        public IDeliveryNoteItemPropertySearchService SearchService { get; set; }
        public IDeliveryNoteItemPropertyUpdateService UpdateService { get; set; }
    }
}
