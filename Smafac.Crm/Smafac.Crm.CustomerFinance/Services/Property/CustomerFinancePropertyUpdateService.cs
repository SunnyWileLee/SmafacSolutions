using Smafac.Crm.CustomerFinance.Applications.Propety;
using Smafac.Crm.CustomerFinance.Domain;
using Smafac.Crm.CustomerFinance.Models;
using Smafac.Crm.CustomerFinance.Repositories.Property;
using Smafac.Framework.Core.Services.Property;

namespace Smafac.Crm.CustomerFinance.Services.Property
{
    class CustomerFinancePropertyUpdateService : PropertyUpdateService<CustomerFinancePropertyEntity, CustomerFinancePropertyModel>, ICustomerFinancePropertyUpdateService
    {
        public CustomerFinancePropertyUpdateService(ICustomerFinancePropertySearchRepository financePropertySearchRepository,
                                          ICustomerFinancePropertyUpdateRepository financePropertyUpdateRepository)
        {
            base.CustomizedColumnSearchRepository = financePropertySearchRepository;
            base.CustomizedColumnUpdateRepository = financePropertyUpdateRepository;
        }
    }
}
