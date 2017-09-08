using Smafac.Crm.CustomerFinance.Domain;
using Smafac.Crm.CustomerFinance.Models;
using System;

namespace Smafac.Crm.CustomerFinance.Repositories
{
    interface ICustomerFinanceRepository
    {
        bool AddCustomerFinance(CustomerFinanceEntity order);
        bool DeleteCustomerFinance(Guid subscriberId, Guid orderId);
    }
}
