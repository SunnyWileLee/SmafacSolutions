using Smafac.Crm.CustomerFinance.Applications.Propety;
using Smafac.Crm.CustomerFinance.Domain;
using Smafac.Crm.CustomerFinance.Model;
using Smafac.Crm.CustomerFinance.Repository.Property;
using Smafac.Framework.Core.Services.Property;

namespace Smafac.Crm.CustomerFinance.Services.Property
{
    class CustomerFinancePropertyAddService : PropertyAddService<CustomerFinancePropertyEntity, CustomerFinancePropertyModel>, ICustomerFinancePropertyAddService
    {
        public CustomerFinancePropertyAddService(ICustomerFinancePropertyAddRepository goodsPropertyAddRepository,
                                        ICustomerFinancePropertySearchRepository goodsPropertySearchRepository)
        {
            base.PropertyAddRepository = goodsPropertyAddRepository;
            base.PropertySearchRepository = goodsPropertySearchRepository;
        }
    }
}
