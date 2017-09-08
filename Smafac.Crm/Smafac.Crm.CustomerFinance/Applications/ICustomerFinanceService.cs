using Smafac.Crm.CustomerFinance.Models;
using System;

namespace Smafac.Crm.CustomerFinance.Applications
{
    public interface ICustomerFinanceService
    {
        ICustomerFinanceUpdateService UpdateService { get; set; }
        bool AddCustomerFinance(CustomerFinanceModel model);
        bool DeleteCustomerFinance(Guid orderId);
        CustomerFinanceModel CreateEmptyCustomerFinance();
    }
}
