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
    class CustomerContactPropertyService : ICustomerContactPropertyService
    {
        private readonly ICustomerContactPropertyRepository _customerContactPropertyRepository;

        public CustomerContactPropertyService(ICustomerContactPropertyRepository customerContactPropertyRepository)
        {
            _customerContactPropertyRepository = customerContactPropertyRepository;
        }

        public bool AddProperty(CustomerContactPropertyModel model)
        {
            var property = Mapper.Map<CustomerContactPropertyEntity>(model);
            property.SubscriberId = UserContext.Current.SubscriberId;
            return _customerContactPropertyRepository.AddProperty(property);
        }

        public bool UpdateProperty(CustomerContactPropertyModel model)
        {
            var property = Mapper.Map<CustomerContactPropertyEntity>(model);
            property.SubscriberId = UserContext.Current.SubscriberId;
            return _customerContactPropertyRepository.UpdateProperty(property);
        }

        public bool DeleteProperty(Guid propertyId)
        {
            return _customerContactPropertyRepository.DeleteProperty(UserContext.Current.SubscriberId, propertyId);
        }

        public List<CustomerContactPropertyModel> GetProperties()
        {
            return _customerContactPropertyRepository.GetPropertyModels(UserContext.Current.SubscriberId);
        }
    }
}
