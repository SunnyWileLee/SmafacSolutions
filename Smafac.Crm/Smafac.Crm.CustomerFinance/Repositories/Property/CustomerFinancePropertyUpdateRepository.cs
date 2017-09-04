using Smafac.Crm.CustomerFinance.Domain;
using Smafac.Framework.Core.Repositories.Property;

namespace Smafac.Crm.CustomerFinance.Repositories.Property
{
    class CustomerFinancePropertyUpdateRepository : PropertyUpdateRepository<CustomerFinanceContext, CustomerFinancePropertyEntity>, ICustomerFinancePropertyUpdateRepository
    {
        public CustomerFinancePropertyUpdateRepository(ICustomerFinanceContextProvider customerFinanceContextProvider)
        {
            base.ContextProvider = customerFinanceContextProvider;
        }
    }
}
