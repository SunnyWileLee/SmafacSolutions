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
        private readonly ICustomerPropertyValueRepository _customerPropertyValueRepository;

        public CustomerPropertyService(ICustomerPropertyRepository customerPropertyRepository,
                                        ICustomerPropertyValueRepository customerPropertyValueRepository
                                    )
        {
            _customerPropertyRepository = customerPropertyRepository;
            _customerPropertyValueRepository = customerPropertyValueRepository;
        }

        public bool AddProperty(CustomerPropertyModel model)
        {
            var property = Mapper.Map<CustomerPropertyEntity>(model);
            property.SubscriberId = UserContext.Current.SubscriberId;
            return _customerPropertyRepository.AddProperty(property);
        }

        public bool UpdateProperty(CustomerPropertyModel model)
        {
            var property = Mapper.Map<CustomerPropertyEntity>(model);
            return _customerPropertyRepository.UpdateProperty(property);
        }

        public bool DeleteProperty(Guid propertyId)
        {
            if (_customerPropertyValueRepository.Any(UserContext.Current.SubscriberId, propertyId))
            {
                return false;
            }
            return _customerPropertyRepository.DeleteProperty(UserContext.Current.SubscriberId, propertyId);
        }

        public List<CustomerPropertyModel> GetProperties()
        {
            var properties = _customerPropertyRepository.GetPropertyModels(UserContext.Current.SubscriberId);
            return properties;
        }
    }
}
