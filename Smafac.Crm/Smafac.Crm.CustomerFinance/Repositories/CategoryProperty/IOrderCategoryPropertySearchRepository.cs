using Smafac.Crm.CustomerFinance.Domain;
using Smafac.Framework.Core.Repositories.CategoryProperty;

namespace Smafac.Crm.CustomerFinance.Repositories.CategoryProperty
{
    interface ICustomerFinanceCategoryPropertySearchRepository : ICategoryPropertySearchRepository<CustomerFinanceCategoryEntity, CustomerFinancePropertyEntity>
    {
    }
}
