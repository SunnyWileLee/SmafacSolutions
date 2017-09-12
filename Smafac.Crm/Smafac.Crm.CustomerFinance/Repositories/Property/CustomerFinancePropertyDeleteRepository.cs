using Smafac.Crm.CustomerFinance.Domain;
using Smafac.Framework.Core.Repositories.Property;

namespace Smafac.Crm.CustomerFinance.Repositories.Property
{
    class CustomerFinancePropertyDeleteRepository : PropertyDeleteRepository<CustomerFinanceContext, CustomerFinancePropertyEntity>, ICustomerFinancePropertyDeleteRepository
    {
        public CustomerFinancePropertyDeleteRepository(ICustomerFinanceContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}
