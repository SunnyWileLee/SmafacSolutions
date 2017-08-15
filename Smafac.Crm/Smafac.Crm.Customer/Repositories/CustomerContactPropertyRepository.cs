using Smafac.Crm.Customer.Domain;
using Smafac.Crm.Customer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Repositories
{
    class CustomerContactPropertyRepository : ICustomerContactPropertyRepository
    {

        private readonly ICustomerContextProvider _customerContextProvider;

        public CustomerContactPropertyRepository(ICustomerContextProvider customerContextProvider)
        {
            _customerContextProvider = customerContextProvider;
        }

        public bool AddProperty(CustomerContactPropertyEntity property)
        {
            using (var context = _customerContextProvider.Provide())
            {
                context.CustomerContactPropertites.Add(property);
                return context.SaveChanges() > 0;
            }
        }

        public bool UpdateProperty(CustomerContactPropertyEntity property)
        {
            using (var context = _customerContextProvider.Provide())
            {
                var entity = context.CustomerContactPropertites.Where(s => s.SubscriberId == property.SubscriberId && s.Id == property.Id).FirstOrDefault();
                entity.Title = property.Title;
                return context.SaveChanges() > 0;
            }
        }

        public bool DeleteProperty(Guid SubscriberId, Guid propertyId)
        {
            using (var context = _customerContextProvider.Provide())
            {
                var property = context.CustomerContactPropertites.Where(s => s.SubscriberId == SubscriberId && s.Id == propertyId).FirstOrDefault();
                if (property == null)
                {
                    return false;
                }
                context.CustomerContactPropertites.Remove(property);
                return context.SaveChanges() > 0;
            }
        }

        public List<CustomerContactPropertyEntity> GetProperties(Guid SubscriberId)
        {
            using (var context = _customerContextProvider.Provide())
            {
                var properties = context.CustomerContactPropertites.Where(s => s.SubscriberId == SubscriberId).ToList();
                return properties;
            }
        }


        public List<CustomerContactPropertyModel> GetPropertyModels(Guid SubscriberId)
        {
            using (var context = _customerContextProvider.Provide())
            {
                var properties = context.CustomerContactPropertites.Where(s => s.SubscriberId == SubscriberId)
                                        .Select(s => new CustomerContactPropertyModel
                                        {
                                            SubscriberId = s.SubscriberId,
                                            CreateTime = s.CreateTime,
                                            Id = s.Id,
                                            Title = s.Title
                                        }).ToList();
                return properties;
            }
        }

        public CustomerContactPropertyEntity GetPropertyById(Guid SubscriberId, Guid propertyId)
        {
            using (var context = _customerContextProvider.Provide())
            {
                var property = context.CustomerContactPropertites.FirstOrDefault(s => s.SubscriberId == SubscriberId && s.Id == propertyId);
                return property;
            }
        }
    }
}
