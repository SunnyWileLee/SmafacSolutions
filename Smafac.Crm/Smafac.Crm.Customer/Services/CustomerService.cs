using AutoMapper;
using Smafac.Crm.Customer.Applications;
using Smafac.Crm.Customer.Domain;
using Smafac.Crm.Customer.Models;
using Smafac.Crm.Customer.Repositories;
using Smafac.Crm.Customer.Repositories.Property;
using Smafac.Crm.Customer.Repositories.PropertyValue;
using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Services
{
    class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerPropertyValueSetRepository _customerPropertyValueSetRepository;
        private readonly ICustomerPropertySearchRepository _customerPropertySearchRepository;

        public ICustomerUpdateService UpdateService { get; set; }

        public CustomerService(ICustomerRepository customerRepository,
                                ICustomerUpdateService customerUpdateService,
                                ICustomerPropertySearchRepository customerPropertySearchRepository,
                                ICustomerPropertyValueSetRepository customerPropertyValueSetRepository)
        {
            _customerRepository = customerRepository;
            _customerPropertySearchRepository = customerPropertySearchRepository;
            _customerPropertyValueSetRepository = customerPropertyValueSetRepository;
            UpdateService = customerUpdateService;
        }

        public bool AddCustomer(CustomerModel model)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var customer = Mapper.Map<CustomerEntity>(model);
            customer.SubscriberId = subscriberId;
            var addCustomer = _customerRepository.AddCustomer(customer);
            if (addCustomer && model.HasProperties)
            {
                model.Properties.ForEach(property =>
                {
                    property.CustomerId = customer.Id;
                    property.SubscriberId = customer.SubscriberId;
                });
                var values = Mapper.Map<List<CustomerPropertyValueEntity>>(model.Properties);
                return _customerPropertyValueSetRepository.AddPropertyValues(customer.Id, values);
            }
            return addCustomer;
        }


        public bool UpdateCustomer(CustomerModel model)
        {
            var customer = Mapper.Map<CustomerEntity>(model);
            customer.SubscriberId = UserContext.Current.SubscriberId;
            return _customerRepository.AddCustomer(customer);
        }

        public bool DeleteCustomer(Guid customerId)
        {
            return _customerRepository.DeleteCustomer(UserContext.Current.SubscriberId, customerId);
        }

        public CustomerModel CreateEmptyCustomer()
        {
            var customer = new CustomerModel();
            var properties = Mapper.Map<List<CustomerPropertyModel>>(_customerPropertySearchRepository.GetEntities(UserContext.Current.SubscriberId, s => true));
            customer.Properties = properties.Select(s => new CustomerPropertyValueModel { PropertyId = s.Id, PropertyName = s.Name }).ToList();
            return customer;
        }
    }
}
