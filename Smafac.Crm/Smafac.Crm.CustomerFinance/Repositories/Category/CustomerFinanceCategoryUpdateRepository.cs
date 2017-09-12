using Smafac.Crm.CustomerFinance.Domain;
using Smafac.Framework.Core.Repositories.Category;

namespace Smafac.Crm.CustomerFinance.Repositories.Category
{
    class CustomerFinanceCategoryUpdateRepository : CategoryUpdateRepository<CustomerFinanceContext, CustomerFinanceCategoryEntity>, ICustomerFinanceCategoryUpdateRepository
    {
        public CustomerFinanceCategoryUpdateRepository(ICustomerFinanceContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}
