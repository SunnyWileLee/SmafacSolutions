using Smafac.Crm.CustomerFinance.Domain;
using Smafac.Framework.Core.Repositories.Property;

namespace Smafac.Crm.CustomerFinance.Repository.Property
{
    class CustomerFinancePropertySearchRepository : PropertySearchRepository<CustomerFinanceContext, CustomerFinancePropertyEntity>, ICustomerFinancePropertySearchRepository
    {
        public CustomerFinancePropertySearchRepository(ICustomerFinanceContextProvider customerFinanceContextProvider)
        {
            base.ContextProvider = customerFinanceContextProvider;
        }
    }
}
