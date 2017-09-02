using Smafac.Crm.CustomerFinance.Domain;
using Smafac.Framework.Core.Repositories.Property;

namespace Smafac.Crm.CustomerFinance.Repository.Property
{
    class CustomerFinancePropertyDeleteRepository : PropertyDeleteRepository<CustomerFinanceContext, CustomerFinancePropertyEntity>, ICustomerFinancePropertyDeleteRepository
    {
        public CustomerFinancePropertyDeleteRepository(ICustomerFinanceContextProvider customerFinanceContextProvider)
        {
            base.ContextProvider = customerFinanceContextProvider;
        }
    }
}
