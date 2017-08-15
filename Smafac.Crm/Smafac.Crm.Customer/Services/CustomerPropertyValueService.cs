using Smafac.Crm.Customer.Applications;
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
    class CustomerPropertyValueService : ICustomerPropertyValueService
    {
        private readonly ICustomerPropertyValueRepository _customerPropertyValueRepository;
        private readonly ICustomerPropertyRepository _customerPropertyRepository;

        public CustomerPropertyValueService(ICustomerPropertyValueRepository customerPropertyValueRepository,
            ICustomerPropertyRepository customerPropertyRepository)
        {
            _customerPropertyValueRepository = customerPropertyValueRepository;
            _customerPropertyRepository = customerPropertyRepository;
        }
        public bool SetPropertyValue(CustomerPropertyValueModel model)
        {
            var property = _customerPropertyRepository.GetPropertyById(UserContext.Current.SubscriberId, model.PropertyId);
            var value = property.SetValue(model.CustomerId, model.Value);
            return _customerPropertyValueRepository.SetPropertyValue(value);
        }

        public List<CustomerPropertyValueModel> GetPropertyValues(Guid customerId)
        {
            var values = _customerPropertyValueRepository.GetPropertyValues(UserContext.Current.SubscriberId, customerId);
            return values;
        }
    }
}
