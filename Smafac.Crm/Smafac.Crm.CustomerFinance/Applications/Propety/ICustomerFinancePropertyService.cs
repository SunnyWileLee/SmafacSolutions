using Smafac.Crm.CustomerFinance.Models;
using Smafac.Framework.Core.Applications.Property;

namespace Smafac.Crm.CustomerFinance.Applications.Propety
{
    public interface ICustomerFinancePropertyService
    {
        ICustomerFinancePropertyAddService AddService { get; set; }
        ICustomerFinancePropertyDeleteService DeleteService { get; set; }
        ICustomerFinancePropertySearchService SearchService { get; set; }
        ICustomerFinancePropertyUpdateService UpdateService { get; set; }
    }
}
