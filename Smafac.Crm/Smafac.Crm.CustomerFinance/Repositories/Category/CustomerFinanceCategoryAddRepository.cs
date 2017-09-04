using Smafac.Crm.CustomerFinance.Domain;
using Smafac.Framework.Core.Repositories.Category;

namespace Smafac.Crm.CustomerFinance.Repositories.Category
{
    class CustomerFinanceCategoryAddRepository : CategoryAddRepository<CustomerFinanceContext, CustomerFinanceCategoryEntity>, ICustomerFinanceCategoryAddRepository
    {
        public CustomerFinanceCategoryAddRepository(ICustomerFinanceContextProvider financeContextProvider)
        {
            base.ContextProvider = financeContextProvider;
        }
    }
}
