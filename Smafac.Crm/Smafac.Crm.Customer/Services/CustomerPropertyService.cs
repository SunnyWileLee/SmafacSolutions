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
    class CustomerPropertyService : ICustomerPropertyService
    {
        private readonly ICustomerPropertyRepository _customerPropertyRepository;
        public CustomerPropertyService(ICustomerPropertyRepository customerPropertyRepository)
        {
            _customerPropertyRepository = customerPropertyRepository;
        }

        public bool AddProperty(CustomerPropertyModel model)
        {
            var property = Mapper.Map<CustomerPropertyEntity>(model);
            return _customerPropertyRepository.AddProperty(property);
        }

        public bool UpdateProperty(CustomerPropertyModel model)
        {
            var property = Mapper.Map<CustomerPropertyEntity>(model);
            return _customerPropertyRepository.UpdateProperty(property);
        }

        public bool DeleteProperty(Guid propertyId)
        {
            return _customerPropertyRepository.DeleteProperty(UserContext.Current.SubscriberId, propertyId);
        }

        public List<CustomerPropertyModel> GetProperties()
        {
            var properties = _customerPropertyRepository.GetPropertyModels(UserContext.Current.SubscriberId);
            return properties;
        }
    }
}
