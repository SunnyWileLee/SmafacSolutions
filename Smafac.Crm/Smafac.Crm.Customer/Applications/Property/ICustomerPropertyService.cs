using Smafac.Crm.Customer.Models;
using Smafac.Framework.Core.Applications.Property;

namespace Smafac.Crm.Customer.Applications.Propety
{
    public interface ICustomerPropertyService
    {
        ICustomerPropertyAddService AddService { get; set; }
        ICustomerPropertyDeleteService DeleteService { get; set; }
        ICustomerPropertySearchService SearchService { get; set; }
        ICustomerPropertyUpdateService UpdateService { get; set; }
    }
}
