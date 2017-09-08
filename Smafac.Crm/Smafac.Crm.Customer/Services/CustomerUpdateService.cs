using Smafac.Crm.Customer.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Crm.Customer.Models;
using Smafac.Crm.Customer.Repositories;
using Smafac.Crm.Customer.Repositories.PropertyValue;
using AutoMapper;
using Smafac.Crm.Customer.Domain;
using Smafac.Framework.Core.Models;

namespace Smafac.Crm.Customer.Services
{
    class CustomerUpdateService : ICustomerUpdateService
    {
        private readonly ICustomerUpdateRepository _customerUpdateRepository;
        private readonly ICustomerPropertyValueSetRepository _customerPropertyValueSetRepository;

        public CustomerUpdateService(ICustomerUpdateRepository customerUpdateRepository,
                                    ICustomerPropertyValueSetRepository customerPropertyValueSetRepository)
        {
            _customerUpdateRepository = customerUpdateRepository;
            _customerPropertyValueSetRepository = customerPropertyValueSetRepository;
        }

        public bool UpdateCustomer(CustomerModel model)
        {
            var customer = Mapper.Map<CustomerEntity>(model);
            customer.SubscriberId = UserContext.Current.SubscriberId;
            var update = _customerUpdateRepository.UpdateEntity(customer);

            if (update && model.HasProperties)
            {
                model.Properties.ForEach(property =>
                {
                    property.CustomerId = customer.Id;
                    property.SubscriberId = customer.SubscriberId;
                    var value = Mapper.Map<CustomerPropertyValueEntity>(property);
                    update &= _customerPropertyValueSetRepository.SetPropertyValue(value);
                });
            }
            return update;
        }
    }
}
