using Smafac.Crm.CustomerFinance.Repositories.PropertyValue;
using Smafac.Framework.Core.Domain.Property;

namespace Smafac.Crm.CustomerFinance.Domain.Property
{
    class CustomerFinancePropertyDeleteValueTrigger : PropertyDeleteValueTrigger<CustomerFinancePropertyEntity, CustomerFinancePropertyValueEntity>,
                                            ICustomerFinancePropertyDeleteTrigger
    {
        public CustomerFinancePropertyDeleteValueTrigger(ICustomerFinancePropertyValueDeleteRepository customerFinancePropertyValueDeleteRepository)
        {
            base.PropertyValueDeleteRepository = customerFinancePropertyValueDeleteRepository;
        }
    }
}
