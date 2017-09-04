using Smafac.Crm.Customer.Applications.Propety;
using Smafac.Crm.Customer.Domain;
using Smafac.Crm.Customer.Models;
using Smafac.Crm.Customer.Repositories.Property;
using Smafac.Framework.Core.Services.Property;

namespace Smafac.Crm.Customer.Services.Property
{
    class CustomerPropertyUpdateService : PropertyUpdateService<CustomerPropertyEntity, CustomerPropertyModel>, ICustomerPropertyUpdateService
    {
        public CustomerPropertyUpdateService(ICustomerPropertySearchRepository goodsPropertySearchRepository,
                                          ICustomerPropertyUpdateRepository goodsPropertyUpdateRepository)
        {
            base.PropertySearchRepository = goodsPropertySearchRepository;
            base.PropertyUpdateRepository = goodsPropertyUpdateRepository;
        }
    }
}
