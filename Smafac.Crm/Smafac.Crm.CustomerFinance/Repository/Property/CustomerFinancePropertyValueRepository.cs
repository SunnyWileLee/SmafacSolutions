using Smafac.Crm.CustomerFinance.Domain;
using Smafac.Crm.CustomerFinance.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Smafac.Crm.CustomerFinance.Repository.Property
{
    class CustomerFinancePropertyValueRepository : ICustomerFinancePropertyValueRepository
    {
        private readonly ICustomerFinanceContextProvider _orderContextProvider;

        public CustomerFinancePropertyValueRepository(ICustomerFinanceContextProvider orderContextProvider)
        {
            _orderContextProvider = orderContextProvider;
        }

        public bool AddPropertyValues(Guid orderId, IEnumerable<CustomerFinancePropertyValueEntity> values)
        {
            using (var context = _orderContextProvider.Provide())
            {
                if (values.Any(s => s.CustomerFinanceId != orderId))
                {
                    return false;
                }
                if (context.CustomerFinancePropertyValues.Any(s => s.CustomerFinanceId == orderId))
                {
                    return false;
                }
                context.CustomerFinancePropertyValues.AddRange(values);
                return context.SaveChanges() > 0;
            }
        }

        public bool Any(Guid subscriberId, Guid propertyId)
        {
            using (var context = _orderContextProvider.Provide())
            {
                return context.CustomerFinancePropertyValues.Any(s => s.SubscriberId == subscriberId && s.PropertyId == propertyId);
            }
        }

        public bool Delete(Guid subscriberId, Guid propertyId)
        {
            using (var context = _orderContextProvider.Provide())
            {
                var properties = context.CustomerFinancePropertyValues.Where(s => s.SubscriberId == subscriberId && s.PropertyId == propertyId).ToList();
                if (!properties.Any())
                {
                    return true;
                }
                context.CustomerFinancePropertyValues.RemoveRange(properties);
                return context.SaveChanges() > 0;
            }
        }

        public List<CustomerFinancePropertyValueModel> GetPropertyValues(Guid subscriberId, Guid orderId)
        {
            using (var context = _orderContextProvider.Provide())
            {
                var query = from value in context.CustomerFinancePropertyValues
                            join property in context.CustomerFinanceProperties on value.PropertyId equals property.Id
                            where value.SubscriberId == subscriberId && value.CustomerFinanceId == orderId
                            select new CustomerFinancePropertyValueModel
                            {
                                Id = value.Id,
                                SubscriberId = value.SubscriberId,
                                CreateTime = value.CreateTime,
                                CustomerFinanceId = value.CustomerFinanceId,
                                PropertyId = value.PropertyId,
                                PropertyName = property.Name,
                                Value = value.Value
                            };
                return query.ToList();
            }
        }

        public IEnumerable<IGrouping<Guid, CustomerFinancePropertyValueModel>> GetPropertyValues(Guid subscriberId, IEnumerable<Guid> orderIds)
        {
            using (var context = _orderContextProvider.Provide())
            {
                var query = from value in context.CustomerFinancePropertyValues
                            join property in context.CustomerFinanceProperties on value.PropertyId equals property.Id
                            where value.SubscriberId == subscriberId && orderIds.Contains(value.CustomerFinanceId)
                            select new CustomerFinancePropertyValueModel
                            {
                                Id = value.Id,
                                SubscriberId = value.SubscriberId,
                                CreateTime = value.CreateTime,
                                CustomerFinanceId = value.CustomerFinanceId,
                                PropertyId = value.PropertyId,
                                PropertyName = property.Name,
                                Value = value.Value
                            };
                return query.ToList().GroupBy(s => s.CustomerFinanceId);
            }
        }

        public bool UpdatePropertyValue(CustomerFinancePropertyValueModel model)
        {
            using (var context = _orderContextProvider.Provide())
            {
                var property = context.CustomerFinancePropertyValues.FirstOrDefault(s => s.SubscriberId == model.SubscriberId && s.Id == model.Id);
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
