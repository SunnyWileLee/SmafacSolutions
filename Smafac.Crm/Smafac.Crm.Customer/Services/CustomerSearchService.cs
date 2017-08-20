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
        public CustomerDetailModel GetCustomerDetail(Guid customerId)
        {
            var customer = _customerSearchRepository.GetById(UserContext.Current.SubscriberId, customerId);
            var model = Mapper.Map<CustomerModel>(customer);
            var properties = _customerPropertyValueRepository.GetPropertyValues(UserContext.Current.SubscriberId, customerId);
            SetCustomerPropertyValues(model, properties);
            return new CustomerDetailModel { SubscriberId = UserContext.Current.SubscriberId, Customer = model };
        }

        public PageModel<CustomerModel> GetCustomerPage(CustomerPageQueryModel query)
        {
            var customers = _customerSearchRepository.GetCustomerPage(query);
            if (customers.Any())
            {
                var properties = _customerPropertyValueRepository.GetPropertyValues(UserContext.Current.SubscriberId, customers.Select(s => s.Id));
                customers.ForEach(customer =>
                {
                    SetCustomerPropertyValues(customer, properties.FirstOrDefault(s => s.Key == customer.Id));
                });
            }
            var count = _customerSearchRepository.GetCustomerCount(query);
            return new PageModel<CustomerModel>
            {
                PageData = customers,
                PageSize = query.PageSize,
                PageIndex = query.PageIndex,
                TotalCount = count
            };
        }

        private void SetCustomerPropertyValues(CustomerModel customer, IEnumerable<CustomerPropertyValueModel> properties)
        {
            if (properties.Any(s => s.CustomerId != customer.Id))
            {
                throw new ArgumentException();
            }
            customer.Properties = properties.ToList();
        }
    }
}
