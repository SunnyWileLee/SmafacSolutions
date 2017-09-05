using Smafac.Crm.CustomerFinance.Models;
using Smafac.Crm.CustomerFinance.Repositories.PropertyValue;
using Smafac.Framework.Core.Domain.Property;

namespace Smafac.Crm.CustomerFinance.Domain.Property
{
    class CustomerFinancePropertyUsedByValueChecker : PropertyUsedByValueChecker<CustomerFinancePropertyEntity, CustomerFinancePropertyValueModel>,
                                                ICustomerFinancePropertyUsedChecker
    {
        public CustomerFinancePropertyUsedByValueChecker(ICustomerFinancePropertyValueSearchRepository customerFinancePropertyValueSearchRepository)
        {
            base.PropertyValueSearchRepository = customerFinancePropertyValueSearchRepository;
        }
    }
}
