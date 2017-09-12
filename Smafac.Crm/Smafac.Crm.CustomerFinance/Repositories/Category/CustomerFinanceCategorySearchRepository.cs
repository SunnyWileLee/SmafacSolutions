using Smafac.Crm.CustomerFinance.Domain;
using Smafac.Framework.Core.Repositories.Category;

namespace Smafac.Crm.CustomerFinance.Repositories.Category
{
    class CustomerFinanceCategorySearchRepository : CategorySearchRepository<CustomerFinanceContext, CustomerFinanceCategoryEntity>, ICustomerFinanceCategorySearchRepository
    {
        public CustomerFinanceCategorySearchRepository(ICustomerFinanceContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}
