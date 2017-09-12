using Smafac.Crm.CustomerFinance.Domain;
using Smafac.Framework.Core.Repositories.Property;

namespace Smafac.Crm.CustomerFinance.Repositories.Property
{
    class CustomerFinancePropertySearchRepository : PropertySearchRepository<CustomerFinanceContext, CustomerFinancePropertyEntity>, ICustomerFinancePropertySearchRepository
    {
        public CustomerFinancePropertySearchRepository(ICustomerFinanceContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}
