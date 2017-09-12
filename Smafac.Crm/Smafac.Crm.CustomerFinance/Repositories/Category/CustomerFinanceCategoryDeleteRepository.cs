using Smafac.Crm.CustomerFinance.Domain;
using Smafac.Framework.Core.Repositories.Category;

namespace Smafac.Crm.CustomerFinance.Repositories.Category
{
    class CustomerFinanceCategoryDeleteRepository : CategoryDeleteRepository<CustomerFinanceContext, CustomerFinanceCategoryEntity>, ICustomerFinanceCategoryDeleteRepository
    {
        public CustomerFinanceCategoryDeleteRepository(ICustomerFinanceContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}
