using Smafac.Crm.CustomerFinance.Domain;
using Smafac.Framework.Core.Repositories.PropertyValue;

namespace Smafac.Crm.CustomerFinance.Repositories.PropertyValue
{
    class CustomerFinancePropertyValueDeleteRepository : PropertyValueDeleteRepository<CustomerFinanceContext, CustomerFinancePropertyValueEntity>,
                                                ICustomerFinancePropertyValueDeleteRepository
    {

        public CustomerFinancePropertyValueDeleteRepository(ICustomerFinanceContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}
