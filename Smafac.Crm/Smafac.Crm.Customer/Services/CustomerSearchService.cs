using Smafac.Crm.Customer.Applications;
using Smafac.Crm.Customer.Models;
using Smafac.Crm.Customer.Repositories;
using Smafac.Framework.Core.Models;
using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Smafac.Crm.Customer.Domain;
using System.Linq.Expressions;
using Smafac.Framework.Core.Repositories.Query;
using Smafac.Crm.Customer.Repositories.Property;
using Smafac.Crm.Customer.Repositories.PropertyValue;
using Smafac.Crm.Customer.Domain.Pages;

namespace Smafac.Crm.Customer.Services
{
    class CustomerSearchService : ICustomerSearchService
    {
        private readonly ICustomerSearchRepository _customerSearchRepository;
        private readonly ICustomerPropertyValueSearchRepository _customerPropertyValueSearchRepository;
        private readonly ICustomerPageQueryer _customerPageQueryer;

        public CustomerSearchService(ICustomerSearchRepository customerSearchRepository,
                                     ICustomerPropertyValueSearchRepository customerPropertyValueSearchRepository,
                                     ICustomerPageQueryer customerPageQueryer)
        {
            _customerSearchRepository = customerSearchRepository;
            _customerPropertyValueSearchRepository = customerPropertyValueSearchRepository;
            _customerPageQueryer = customerPageQueryer;
        }

        public CustomerModel GetCustomer(Guid customerId)
        {
            var customer = _customerSearchRepository.GetById(UserContext.Current.SubscriberId, customerId);
            var model = Mapper.Map<CustomerModel>(customer);
            var properties = _customerPropertyValueSearchRepository.GetPropertyValues(UserContext.Current.SubscriberId, customerId);
            SetCustomerPropertyValues(model, properties);
            return model;
        }

        public CustomerDetailModel GetCustomerDetail(Guid customerId)
        {
            var customer = GetCustomer(customerId);
            return new CustomerDetailModel { SubscriberId = UserContext.Current.SubscriberId, Customer = customer };
        }

        public PageModel<CustomerModel> GetCustomerPage(CustomerPageQueryModel query)
        {
            return _customerPageQueryer.Query(query);
        }

        public List<CustomerModel> GetCustomers(IEnumerable<Guid> customerIds)
        {
            Expression<Func<CustomerEntity, bool>> predicate = s => customerIds.Contains(s.Id);
            var subscriberId = UserContext.Current.SubscriberId;
            var customers = _customerSearchRepository.GetCustomers(subscriberId, predicate);
            return Mapper.Map<List<CustomerModel>>(customers);
        }

        public List<CustomerModel> GetCustomers()
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var customers = _customerSearchRepository.GetCustomers(subscriberId, s => true);
            return Mapper.Map<List<CustomerModel>>(customers);
        }

        private void SetCustomerPropertyValues(CustomerModel customer, IEnumerable<CustomerPropertyValueModel> properties)
        {
            if (properties == null)
            {
                return;
            }
            if (properties.Any(s => s.CustomerId != customer.Id))
            {
                throw new ArgumentException();
            }
            customer.Properties = properties.ToList();
        }
    }
}
