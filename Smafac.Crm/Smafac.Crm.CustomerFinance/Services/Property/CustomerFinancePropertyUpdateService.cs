using Smafac.Crm.CustomerFinance.Applications.Propety;
using Smafac.Crm.CustomerFinance.Domain;
using Smafac.Crm.CustomerFinance.Models;
using Smafac.Crm.CustomerFinance.Repository.Property;
using Smafac.Framework.Core.Services.Property;

namespace Smafac.Crm.CustomerFinance.Services.Property
{
    class CustomerFinancePropertyUpdateService : PropertyUpdateService<CustomerFinancePropertyEntity, CustomerFinancePropertyModel>, ICustomerFinancePropertyUpdateService
    {
        public CustomerFinancePropertyUpdateService(ICustomerFinancePropertySearchRepository goodsPropertySearchRepository,
                                          ICustomerFinancePropertyUpdateRepository goodsPropertyUpdateRepository)
        {
            base.PropertySearchRepository = goodsPropertySearchRepository;
            base.PropertyUpdateRepository = goodsPropertyUpdateRepository;
        }
    }
}
