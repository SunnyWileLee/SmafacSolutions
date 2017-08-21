using AutoMapper;
using Smafac.Crm.Customer.Applications;
using Smafac.Crm.Customer.Domain;
using Smafac.Crm.Customer.Models;
using Smafac.Crm.Customer.Repositories;
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
        private readonly ICustomerPropertyRepository _customerPropertyRepository;

        public CustomerService(ICustomerRepository customerRepository,
                                ICustomerPropertyRepository customerPropertyRepository)
        {
            _customerRepository = customerRepository;
            _customerPropertyRepository = customerPropertyRepository;
        }

        public bool AddCustomer(CustomerModel model)
        {
            var customer = Mapper.Map<CustomerEntity>(model);
            customer.SubscriberId = UserContext.Current.SubscriberId;
            return _customerRepository.AddCustomer(customer);
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
            var properties = _customerPropertyRepository.GetProperties(UserContext.Current.SubscriberId);
            customer.Properties = properties.Select(s => new CustomerPropertyValueModel { PropertyId = s.Id, PropertyName = s.Name }).ToList();
            return customer;
        }
    }
}
