using Smafac.Crm.Customer.Domain;
using Smafac.Crm.Customer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Repositories
{
    interface ICustomerFinancialStatusRepository
    {
        bool AddFinancialStatus(CustomerFinancialStatusEntity financialStatus);
        bool UpdateFinancialStatus(CustomerFinancialStatusEntity financialStatus);
        bool DeleteFinancialStatus(Guid SubscriberId, Guid financialStatusId);
        List<CustomerFinancialStatusEntity> GetFinancialStatuss(Guid SubscriberId);
        List<CustomerFinancialStatusModel> GetFinancialStatusModels(Guid SubscriberId);
    }
}
