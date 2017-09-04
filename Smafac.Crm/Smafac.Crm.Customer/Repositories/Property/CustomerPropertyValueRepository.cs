using Smafac.Crm.Customer.Domain;
using Smafac.Crm.Customer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Smafac.Crm.Customer.Repositories.Property
{
    class CustomerPropertyValueRepository : ICustomerPropertyValueRepository
    {
        private readonly ICustomerContextProvider _orderContextProvider;

        public CustomerPropertyValueRepository(ICustomerContextProvider orderContextProvider)
        {
            _orderContextProvider = orderContextProvider;
        }

        public bool AddPropertyValues(Guid orderId, IEnumerable<CustomerPropertyValueEntity> values)
        {
            using (var context = _orderContextProvider.Provide())
            {
                if (values.Any(s => s.CustomerId != orderId))
                {
                    return false;
                }
                if (context.CustomerPropertyValues.Any(s => s.CustomerId == orderId))
                {
                    return false;
                }
                context.CustomerPropertyValues.AddRange(values);
                return context.SaveChanges() > 0;
            }
        }

        public bool Any(Guid subscriberId, Guid propertyId)
        {
            using (var context = _orderContextProvider.Provide())
            {
                return context.CustomerPropertyValues.Any(s => s.SubscriberId == subscriberId && s.PropertyId == propertyId);
            }
        }

        public bool Delete(Guid subscriberId, Guid propertyId)
        {
            using (var context = _orderContextProvider.Provide())
            {
                var properties = context.CustomerPropertyValues.Where(s => s.SubscriberId == subscriberId && s.PropertyId == propertyId).ToList();
                if (!properties.Any())
                {
                    return true;
                }
                context.CustomerPropertyValues.RemoveRange(properties);
                return context.SaveChanges() > 0;
            }
        }

        public List<CustomerPropertyValueModel> GetPropertyValues(Guid subscriberId, Guid orderId)
        {
            using (var context = _orderContextProvider.Provide())
            {
                var query = from value in context.CustomerPropertyValues
                            join property in context.CustomerProperties on value.PropertyId equals property.Id
                            where value.SubscriberId == subscriberId && value.CustomerId == orderId
                            select new CustomerPropertyValueModel
                            {
                                Id = value.Id,
                                SubscriberId = value.SubscriberId,
                                CreateTime = value.CreateTime,
                                CustomerId = value.CustomerId,
                                PropertyId = value.PropertyId,
                                PropertyName = property.Name,
                                Value = value.Value
                            };
                return query.ToList();
            }
        }

        public IEnumerable<IGrouping<Guid, CustomerPropertyValueModel>> GetPropertyValues(Guid subscriberId, IEnumerable<Guid> orderIds)
        {
            using (var context = _orderContextProvider.Provide())
            {
                var query = from value in context.CustomerPropertyValues
                            join property in context.CustomerProperties on value.PropertyId equals property.Id
                            where value.SubscriberId == subscriberId && orderIds.Contains(value.CustomerId)
                            select new CustomerPropertyValueModel
                            {
                                Id = value.Id,
                                SubscriberId = value.SubscriberId,
                                CreateTime = value.CreateTime,
                                CustomerId = value.CustomerId,
                                PropertyId = value.PropertyId,
                                PropertyName = property.Name,
                                Value = value.Value
                            };
                return query.ToList().GroupBy(s => s.CustomerId);
            }
        }

        public bool UpdatePropertyValue(CustomerPropertyValueModel model)
        {
            using (var context = _orderContextProvider.Provide())
            {
                var property = context.CustomerPropertyValues.FirstOrDefault(s => s.SubscriberId == model.SubscriberId && s.Id == model.Id);
                if (property == null)
                {
                    return false;
                }
                property.Value = model.Value;
                return context.SaveChanges() > 0;
            }
        }
    }
}
