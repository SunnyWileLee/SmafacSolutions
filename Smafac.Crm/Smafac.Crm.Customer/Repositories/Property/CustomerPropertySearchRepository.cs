using Smafac.Crm.Customer.Domain;
using Smafac.Framework.Core.Repositories.Property;

namespace Smafac.Crm.Customer.Repositories.Property
{
    class CustomerPropertySearchRepository : PropertySearchRepository<CustomerContext, CustomerPropertyEntity>, ICustomerPropertySearchRepository
    {
        public CustomerPropertySearchRepository(ICustomerContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}
