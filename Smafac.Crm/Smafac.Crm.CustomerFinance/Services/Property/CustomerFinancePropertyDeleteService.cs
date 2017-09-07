using Smafac.Crm.CustomerFinance.Applications.Propety;
using Smafac.Crm.CustomerFinance.Domain;
using Smafac.Crm.CustomerFinance.Domain.Property;
using Smafac.Crm.CustomerFinance.Models;
using Smafac.Crm.CustomerFinance.Repositories.Property;
using Smafac.Framework.Core.Services.Property;
using System;

namespace Smafac.Crm.CustomerFinance.Services.Property
{
    class CustomerFinancePropertyDeleteService : PropertyDeleteService<CustomerFinancePropertyEntity, CustomerFinancePropertyModel>, ICustomerFinancePropertyDeleteService
    {
        public CustomerFinancePropertyDeleteService(ICustomerFinancePropertyDeleteRepository customerFinancePropertyDeleteRepository,
                                                    ICustomerFinancePropertySearchRepository customerFinancePropertySearchRepository,
                                                    ICustomerFinancePropertyUsedChecker[] customerFinancePropertyUsedCheckers,
                                                    ICustomerFinancePropertyDeleteTrigger[] customerFinancePropertyDeleteTriggers)
        {
            base.CustomizedColumnDeleteRepository = customerFinancePropertyDeleteRepository;
            base.CustomizedColumnUsedCheckers = customerFinancePropertyUsedCheckers;
            base.CustomizedColumnSearchRepository = customerFinancePropertySearchRepository;
            base.CustomizedColumnDeleteTriggers = customerFinancePropertyDeleteTriggers;
        }

    }
}
