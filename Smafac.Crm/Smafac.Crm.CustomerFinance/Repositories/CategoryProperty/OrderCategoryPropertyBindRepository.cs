using Smafac.Crm.CustomerFinance.Domain;
using Smafac.Framework.Core.Repositories.CategoryProperty;

namespace Smafac.Crm.CustomerFinance.Repositories.CategoryProperty
{
    class CustomerFinanceCategoryPropertyBindRepository : CategoryPropertyBindRepository<CustomerFinanceContext, CustomerFinanceCategoryEntity, CustomerFinancePropertyEntity, CustomerFinanceCategoryPropertyEntity>,
                                                ICustomerFinanceCategoryPropertyBindRepository
    {
        public CustomerFinanceCategoryPropertyBindRepository(ICustomerFinanceContextProvider financeContextProvider)
        {
            base.ContextProvider = financeContextProvider;
        }
    }
}
