using Smafac.Crm.Customer.Domain;
using Smafac.Crm.Customer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Repositories
{
    class CustomerContactPropertyValueRepository : ICustomerContactPropertyValueRepository
    {

        private readonly ICustomerContextProvider _customerContextProvider;

        public CustomerContactPropertyValueRepository(ICustomerContextProvider customerContextProvider)
        {
            _customerContextProvider = customerContextProvider;
        }

        public bool SetPropertyValue(CustomerContactPropertyValueEntity value)
        {
            using (var context = _customerContextProvider.Provide())
            {
                var entity = context.CustomerContactPropertyValues.FirstOrDefault(s => s.SubscriberId == value.SubscriberId && s.PropertyId == value.PropertyId);
                if (entity == null)
                {
                    context.CustomerContactPropertyValues.Add(value);
                }
                else
                {
                    entity.Value = value.Value;
                }
                return context.SaveChanges() > 0;
            }
        }

        public List<CustomerContactPropertyValueModel> GetPropertyValues(Guid SubscriberId, Guid contactId)
        {
            using (var context = _customerContextProvider.Provide())
            {
                var values = context.CustomerContactPropertyValues.Where(s => s.SubscriberId == SubscriberId && s.ContactId == contactId)
                                    .Select(s => new CustomerContactPropertyValueModel
                                    {
                                        SubscriberId = s.SubscriberId,
                                        CreateTime = s.CreateTime,
                                        Id = s.Id,
                                        ContactId = s.ContactId,
                                        PropertyId = s.PropertyId,
                                        Value = s.Value
                                    }).ToList();
                return values;
            }
        }
    }
}
