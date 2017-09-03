using Smafac.Crm.CustomerFinance.Domain;
using Smafac.Crm.CustomerFinance.Models;
using System;

namespace Smafac.Crm.CustomerFinance.Repository
{
    interface ICustomerFinanceRepository
    {
        bool AddCustomerFinance(CustomerFinanceEntity order);
        bool UpdateCustomerFinance(CustomerFinanceModel model);
        bool DeleteCustomerFinance(Guid subscriberId, Guid orderId);
    }
}
