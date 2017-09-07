using Smafac.Crm.CustomerFinance.Applications.Propety;
using Smafac.Crm.CustomerFinance.Domain;
using Smafac.Crm.CustomerFinance.Models;
using Smafac.Crm.CustomerFinance.Repositories.Property;
using Smafac.Framework.Core.Services.Property;

namespace Smafac.Crm.CustomerFinance.Services.Property
{
    class CustomerFinancePropertyAddService : PropertyAddService<CustomerFinancePropertyEntity, CustomerFinancePropertyModel>, ICustomerFinancePropertyAddService
    {
        public CustomerFinancePropertyAddService(ICustomerFinancePropertyAddRepository financePropertyAddRepository,
                                        ICustomerFinancePropertySearchRepository financePropertySearchRepository)
        {
            base.CustomizedColumnAddRepository = financePropertyAddRepository;
            base.CustomizedColumnSearchRepository = financePropertySearchRepository;
        }
    }
}
