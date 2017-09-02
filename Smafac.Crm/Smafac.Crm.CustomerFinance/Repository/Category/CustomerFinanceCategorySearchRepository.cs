using Smafac.Crm.CustomerFinance.Domain;
using Smafac.Framework.Core.Repositories.Category;

namespace Smafac.Crm.CustomerFinance.Repository.Category
{
    class CustomerFinanceCategorySearchRepository : CategorySearchRepository<CustomerFinanceContext, CustomerFinanceCategoryEntity>, ICustomerFinanceCategorySearchRepository
    {
        public CustomerFinanceCategorySearchRepository(ICustomerFinanceContextProvider financeContextProvider)
        {
            base.ContextProvider = financeContextProvider;
        }
    }
}
