using Smafac.Crm.Customer.Applications;
using Smafac.Crm.Customer.Models;
using Smafac.Crm.Customer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Smafac.Crm.Customer.Domain;
using Smafac.Framework.Core.Models;

namespace Smafac.Crm.Customer.Services
{
    class CustomerContactPropertyValueService : ICustomerContactPropertyValueService
    {
        private readonly ICustomerContactPropertyValueRepository _customerContactPropertyValueRepository;

        public CustomerContactPropertyValueService(ICustomerContactPropertyValueRepository customerContactPropertyValueRepository)
        {
            _customerContactPropertyValueRepository = customerContactPropertyValueRepository;
        }

        public bool SetPropertyValue(CustomerContactPropertyValueModel model)
        {
            var value = Mapper.Map<CustomerContactPropertyValueEntity>(model);
            value.SubscriberId = UserContext.Current.SubscriberId;
            return _customerContactPropertyValueRepository.SetPropertyValue(value);
        }

        public List<CustomerContactPropertyValueModel> GetPropertyValues(Guid contactId)
        {
            var values = _customerContactPropertyValueRepository.GetPropertyValues(UserContext.Current.SubscriberId, contactId);
            return values;
        }
    }
}
