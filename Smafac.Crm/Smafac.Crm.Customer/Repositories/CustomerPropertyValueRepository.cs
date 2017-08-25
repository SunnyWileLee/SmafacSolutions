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
                var entity = context.CustomerPropertyValues.FirstOrDefault(s => s.SubscriberId == value.SubscriberId && s.CustomerId == value.CustomerId && s.PropertyId == value.PropertyId);
                if (entity == null)
                {
                    context.CustomerPropertyValues.Add(value);
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
                var values = context.CustomerPropertyValues.Where(s => s.SubscriberId == SubscriberId && s.CustomerId == customerId);
                return JoinProperyName(values, context.CustomerProperties).ToList();
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
                var values = context.CustomerPropertyValues.Where(s => s.SubscriberId == SubscriberId && customerIds.Contains(s.CustomerId));
                var models = JoinProperyName(values, context.CustomerProperties);
                return models.GroupBy(s => s.CustomerId);
            }
        }

        private IEnumerable<CustomerPropertyValueModel> JoinProperyName(IQueryable<CustomerPropertyValueEntity> values,
                                                                        IQueryable<CustomerPropertyEntity> properties)
        {
            var query = from value in values
                        join property in properties on value.PropertyId equals property.Id
                        select new CustomerPropertyValueModel
                        {
                            SubscriberId = value.SubscriberId,
                            CreateTime = value.CreateTime,
                            Id = value.Id,
                            CustomerId = value.CustomerId,
                            PropertyId = value.PropertyId,
                            Value = value.Value,
                            PropertyName = property.Name
                        };
            return query.ToList();
        }

        public bool Any(Guid subscriberId, Guid propertyId)
        {
            using (var context = _customerContextProvider.Provide())
            {
                return context.CustomerPropertyValues.Any(s => s.SubscriberId == subscriberId && s.PropertyId == propertyId);
            }
        }

        public bool AddPropertyValues(Guid subscriberId, Guid customerId, IEnumerable<CustomerPropertyValueEntity> values)
        {
            using (var context = _customerContextProvider.Provide())
            {
                if (!context.Customers.Any(s => s.Id == customerId && s.SubscriberId == subscriberId))
                {
                    return false;
                }
                if (context.CustomerPropertyValues.Any(s => s.SubscriberId == subscriberId && s.CustomerId == customerId))
                {
                    return false;
                }
                if (values.Any(s => s.CustomerId != customerId || s.SubscriberId != subscriberId))
                {
                    return false;
                }
                context.CustomerPropertyValues.AddRange(values);
                return context.SaveChanges() > 0;
            }
        }
    }
}
