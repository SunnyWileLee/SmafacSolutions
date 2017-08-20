using Smafac.Crm.Customer.Domain;
using Smafac.Crm.Customer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Repositories
{
    class CustomerPropertyValueRepository : ICustomerPropertyValueRepository
    {
        private readonly ICustomerContextProvider _customerContextProvider;

        public CustomerPropertyValueRepository(ICustomerContextProvider customerContextProvider)
        {
            _customerContextProvider = customerContextProvider;
        }

        public bool SetPropertyValue(CustomerPropertyValueEntity value)
        {
            using (var context = _customerContextProvider.Provide())
            {
                var entity = context.CustomerPropertityValues.FirstOrDefault(s => s.SubscriberId == value.SubscriberId && s.PropertyId == value.PropertyId);
                if (entity == null)
                {
                    context.CustomerPropertityValues.Add(value);
                }
                else
                {
                    entity.Value = value.Value;
                }
                return context.SaveChanges() > 0;
            }
        }

        public List<CustomerPropertyValueModel> GetPropertyValues(Guid SubscriberId, Guid customerId)
        {
            using (var context = _customerContextProvider.Provide())
            {
                var values = context.CustomerPropertityValues.Where(s => s.SubscriberId == SubscriberId && s.CustomerId == customerId)
                                    .Select(s => new CustomerPropertyValueModel
                                    {
                                        SubscriberId = s.SubscriberId,
                                        CreateTime = s.CreateTime,
                                        Id = s.Id,
                                        CustomerId = s.CustomerId,
                                        PropertyId = s.PropertyId,
                                        Value = s.Value
                                    }).ToList();
                return values;
            }
        }

        public IEnumerable<IGrouping<Guid, CustomerPropertyValueModel>> GetPropertyValues(Guid SubscriberId, IEnumerable<Guid> customerIds)
        {
            if (!customerIds.Any())
            {
                throw new ArgumentNullException("customerIds");
            }
            using (var context = _customerContextProvider.Provide())
            {
                var values = context.CustomerPropertityValues.Where(s => s.SubscriberId == SubscriberId && customerIds.Contains(s.CustomerId))
                                    .Select(s => new CustomerPropertyValueModel
                                    {
                                        SubscriberId = s.SubscriberId,
                                        CreateTime = s.CreateTime,
                                        Id = s.Id,
                                        CustomerId = s.CustomerId,
                                        PropertyId = s.PropertyId,
                                        Value = s.Value
                                    }).ToList();
                return values.GroupBy(s => s.CustomerId);
            }
        }
    }
}
