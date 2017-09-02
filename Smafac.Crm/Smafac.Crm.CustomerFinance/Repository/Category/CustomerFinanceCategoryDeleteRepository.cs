using Smafac.Crm.CustomerFinance.Domain;
using Smafac.Framework.Core.Repositories.Category;

namespace Smafac.Crm.CustomerFinance.Repository.Category
{
    class CustomerFinanceCategoryDeleteRepository : CategoryDeleteRepository<CustomerFinanceContext, CustomerFinanceCategoryEntity>, ICustomerFinanceCategoryDeleteRepository
    {
        public CustomerFinanceCategoryDeleteRepository(ICustomerFinanceContextProvider financeContextProvider)
        {
            base.ContextProvider = financeContextProvider;
        }
    }
}
