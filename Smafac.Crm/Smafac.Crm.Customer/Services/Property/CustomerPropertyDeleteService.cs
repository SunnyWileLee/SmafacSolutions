using Smafac.Crm.Customer.Applications.Propety;
using Smafac.Crm.Customer.Domain;
using Smafac.Crm.Customer.Domain.Property;
using Smafac.Crm.Customer.Models;
using Smafac.Crm.Customer.Repositories.Property;
using Smafac.Framework.Core.Services.Property;
using System;

namespace Smafac.Crm.Customer.Services.Property
{
    class CustomerPropertyDeleteService : PropertyDeleteService<CustomerPropertyEntity, CustomerPropertyModel>, ICustomerPropertyDeleteService
    {
        public CustomerPropertyDeleteService(ICustomerPropertyDeleteRepository customerPropertyDeleteRepository,
                                            ICustomerPropertySearchRepository customerPropertySearchRepository,
                                            ICustomerPropertyUsedChecker[] customerPropertyUsedCheckers)
        {
            base.PropertyDeleteRepository = customerPropertyDeleteRepository;
            base.PropertySearchRepository = customerPropertySearchRepository;
            base.PropertyUsedCheckers = customerPropertyUsedCheckers;
        }
    }
}
