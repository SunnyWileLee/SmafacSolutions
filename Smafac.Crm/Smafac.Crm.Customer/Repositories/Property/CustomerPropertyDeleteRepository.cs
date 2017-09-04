using Smafac.Crm.Customer.Domain;
using Smafac.Framework.Core.Repositories.Property;

namespace Smafac.Crm.Customer.Repositories.Property
{
    class CustomerPropertyDeleteRepository : PropertyDeleteRepository<CustomerContext, CustomerPropertyEntity>, ICustomerPropertyDeleteRepository
    {
        public CustomerPropertyDeleteRepository(ICustomerContextProvider customerFinanceContextProvider)
        {
            base.ContextProvider = customerFinanceContextProvider;
        }
    }
}
