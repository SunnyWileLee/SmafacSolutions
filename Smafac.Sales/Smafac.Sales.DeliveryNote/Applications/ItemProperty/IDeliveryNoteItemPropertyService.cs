namespace Smafac.Sales.DeliveryNote.Applications.ItemProperty
{
    public interface IDeliveryNoteItemPropertyService 
    {
        IDeliveryNoteItemPropertyAddService AddService { get; set; }
        IDeliveryNoteItemPropertyDeleteService DeleteService { get; set; }
        IDeliveryNoteItemPropertySearchService SearchService { get; set; }
        IDeliveryNoteItemPropertyUpdateService UpdateService { get; set; }
    }
}
