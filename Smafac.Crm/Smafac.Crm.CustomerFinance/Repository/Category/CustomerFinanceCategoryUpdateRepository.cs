using Smafac.Crm.CustomerFinance.Domain;
using Smafac.Framework.Core.Repositories.Category;

namespace Smafac.Crm.CustomerFinance.Repository.Category
{
    class CustomerFinanceCategoryUpdateRepository : CategoryUpdateRepository<CustomerFinanceContext, CustomerFinanceCategoryEntity>, ICustomerFinanceCategoryUpdateRepository
    {
        public CustomerFinanceCategoryUpdateRepository(ICustomerFinanceContextProvider financeContextProvider)
        {
            base.ContextProvider = financeContextProvider;
        }
    }
}
