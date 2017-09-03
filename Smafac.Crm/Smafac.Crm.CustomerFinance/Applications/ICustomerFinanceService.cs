using Smafac.Crm.CustomerFinance.Models;
using System;

namespace Smafac.Crm.CustomerFinance.Applications
{
    public interface ICustomerFinanceService
    {
        bool AddCustomerFinance(CustomerFinanceModel model);
        bool UpdateCustomerFinance(CustomerFinanceModel model);
        bool DeleteCustomerFinance(Guid orderId);
        CustomerFinanceModel CreateEmptyCustomerFinance();
    }
}
