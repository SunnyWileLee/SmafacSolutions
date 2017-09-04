using Smafac.Crm.Customer.Domain;
using Smafac.Framework.Core.Repositories.Property;

namespace Smafac.Crm.Customer.Repositories.Property
{
    class CustomerPropertyUpdateRepository : PropertyUpdateRepository<CustomerContext, CustomerPropertyEntity>, ICustomerPropertyUpdateRepository
    {
        public CustomerPropertyUpdateRepository(ICustomerContextProvider customerFinanceContextProvider)
        {
            base.ContextProvider = customerFinanceContextProvider;
        }
    }
}
