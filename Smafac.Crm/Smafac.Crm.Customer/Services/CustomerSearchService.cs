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

namespace Smafac.Crm.Customer.Services
{
    class CustomerSearchService : ICustomerSearchService
    {
        private readonly ICustomerSearchRepository _customerSearchRepository;
        private readonly ICustomerPropertyValueRepository _customerPropertyValueRepository;

        public CustomerSearchService(ICustomerSearchRepository customerSearchRepository,
                                    ICustomerPropertyValueRepository customerPropertyValueRepository)
        {
            _customerSearchRepository = customerSearchRepository;
            _customerPropertyValueRepository = customerPropertyValueRepository;
        }

        public CustomerModel GetCustomer(Guid customerId)
        {
            var customer = _customerSearchRepository.GetById(UserContext.Current.SubscriberId, customerId);
            var model = Mapper.Map<CustomerModel>(customer);
            var properties = _customerPropertyValueRepository.GetPropertyValues(UserContext.Current.SubscriberId, customerId);
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
            var predicate = query.CreatePredicate<CustomerEntity>();
            var subscriberId = UserContext.Current.SubscriberId;
            var customers = _customerSearchRepository.GetCustomerPage(subscriberId, predicate, query.Skip, query.PageSize);
            var models = Mapper.Map<List<CustomerModel>>(customers);
            if (models.Any())
            {
                var properties = _customerPropertyValueRepository.GetPropertyValues(UserContext.Current.SubscriberId, customers.Select(s => s.Id));
                models.ForEach(customer =>
                {
                    SetCustomerPropertyValues(customer, properties.FirstOrDefault(s => s.Key == customer.Id));
                });
            }
            var count = _customerSearchRepository.GetCustomerCount(subscriberId, predicate);
            return new PageModel<CustomerModel>(query)
            {
                PageData = models,
                TotalCount = count
            };
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
