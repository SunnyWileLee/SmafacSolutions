using Smafac.Crm.CustomerFinance.Domain;
using Smafac.Framework.Core.Repositories.CategoryProperty;

namespace Smafac.Crm.CustomerFinance.Repositories.CategoryProperty
{
    interface ICustomerFinanceCategoryPropertyBindRepository : ICategoryPropertyBindRepository<CustomerFinanceCategoryEntity, CustomerFinancePropertyEntity>
    {
    }
}
