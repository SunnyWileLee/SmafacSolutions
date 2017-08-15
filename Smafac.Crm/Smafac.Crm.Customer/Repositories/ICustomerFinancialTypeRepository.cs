using Smafac.Crm.Customer.Domain;
using Smafac.Crm.Customer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Repositories
{
    interface ICustomerFinancialTypeRepository
    {
        bool AddFinancialType(CustomerFinancialTypeEntity financialType);
        bool UpdateFinancialType(CustomerFinancialTypeEntity financialType);
        bool DeleteFinancialType(Guid SubscriberId, Guid financialTypeId);
        List<CustomerFinancialTypeEntity> GetFinancialTypes(Guid SubscriberId);
        List<CustomerFinancialTypeModel> GetFinancialTypeModels(Guid SubscriberId);
    }
}
