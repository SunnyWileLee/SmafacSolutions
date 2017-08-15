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
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
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
    }
}
