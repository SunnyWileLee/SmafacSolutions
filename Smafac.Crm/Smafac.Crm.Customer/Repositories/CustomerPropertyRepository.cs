using Smafac.Crm.Customer.Domain;
using Smafac.Crm.Customer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Repositories
{
    class CustomerPropertyRepository : ICustomerPropertyRepository
    {

        private readonly ICustomerContextProvider _customerContextProvider;

        public CustomerPropertyRepository(ICustomerContextProvider customerContextProvider)
        {
            _customerContextProvider = customerContextProvider;
        }

        public bool AddProperty(CustomerPropertyEntity property)
        {
            using (var context = _customerContextProvider.Provide())
            {
                context.CustomerProperties.Add(property);
                return context.SaveChanges() > 0;
            }
        }

        public bool UpdateProperty(CustomerPropertyEntity property)
        {
            using (var context = _customerContextProvider.Provide())
            {
                var entity = context.CustomerProperties.Where(s => s.SubscriberId == property.SubscriberId && s.Id == property.Id).FirstOrDefault();
                entity.Name = property.Name;
                return context.SaveChanges() > 0;
            }
        }

        public bool DeleteProperty(Guid SubscriberId, Guid propertyId)
        {
            using (var context = _customerContextProvider.Provide())
            {
                var property = context.CustomerProperties.Where(s => s.SubscriberId == SubscriberId && s.Id == propertyId).FirstOrDefault();
                context.CustomerProperties.Remove(property);
                return context.SaveChanges() > 0;
            }
        }

        public List<CustomerPropertyEntity> GetProperties(Guid SubscriberId)
        {
            using (var context = _customerContextProvider.Provide())
            {
                var properties = context.CustomerProperties.Where(s => s.SubscriberId == SubscriberId).ToList();
                return properties;
            }
        }


        public List<CustomerPropertyModel> GetPropertyModels(Guid SubscriberId)
        {
            using (var context = _customerContextProvider.Provide())
            {
                var properties = context.CustomerProperties.Where(s => s.SubscriberId == SubscriberId)
                                        .Select(s => new CustomerPropertyModel
                                        {
                                            SubscriberId = s.SubscriberId,
                                            CreateTime = s.CreateTime,
                                            Id = s.Id,
                                            Name = s.Name
                                        }).ToList();
                return properties;
            }
        }

        public CustomerPropertyEntity GetPropertyById(Guid SubscriberId, Guid propertyId)
        {
            using (var context = _customerContextProvider.Provide())
            {
                var property = context.CustomerProperties.FirstOrDefault(s => s.SubscriberId == SubscriberId && s.Id == propertyId);
                return property;
            }
        }
    }
}
