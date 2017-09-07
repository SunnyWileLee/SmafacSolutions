using Smafac.Crm.Customer.Applications.Propety;
using Smafac.Crm.Customer.Domain;
using Smafac.Crm.Customer.Domain.Property;
using Smafac.Crm.Customer.Models;
using Smafac.Crm.Customer.Repositories.Property;
using Smafac.Framework.Core.Services.Property;

namespace Smafac.Crm.Customer.Services.Property
{
    class CustomerPropertyAddService : PropertyAddService<CustomerPropertyEntity, CustomerPropertyModel>, ICustomerPropertyAddService
    {
        public CustomerPropertyAddService(ICustomerPropertyAddRepository goodsPropertyAddRepository,
                                            ICustomerPropertySearchRepository goodsPropertySearchRepository,
                                            ICustomerPropertyAddTrigger[] customerPropertyAddTrigger)
        {
            base.PropertyAddRepository = goodsPropertyAddRepository;
            base.PropertySearchRepository = goodsPropertySearchRepository;
            base.PropertyAddTriggers = customerPropertyAddTrigger;
        }
    }
}
