using Smafac.Crm.CustomerFinance.Domain;
using Smafac.Crm.CustomerFinance.Models;
using Smafac.Framework.Core.Repositories.PropertyValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Smafac.Crm.CustomerFinance.Repositories.PropertyValue
{
    class CustomerFinancePropertyValueSearchRepository : PropertyValueSearchRepository<CustomerFinanceContext, CustomerFinancePropertyValueEntity, CustomerFinancePropertyEntity, CustomerFinancePropertyValueModel>
                                                , ICustomerFinancePropertyValueSearchRepository
    {
        public CustomerFinancePropertyValueSearchRepository(ICustomerFinanceContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }

        protected override Expression<Func<CustomerFinancePropertyValueEntity, bool>> CreateEntityQueryExpression(Guid entityId)
        {
            return s => s.CustomerFinanceId.Equals(entityId);
        }

        protected override Expression<Func<CustomerFinancePropertyValueEntity, bool>> CreateEntityQueryExpression(IEnumerable<Guid> entityIds)
        {
            return s => entityIds.Contains(s.CustomerFinanceId);
        }

        protected override IEnumerable<IGrouping<Guid, CustomerFinancePropertyValueModel>> GroupValues(IEnumerable<CustomerFinancePropertyValueModel> values)
        {
            return values.GroupBy(s => s.CustomerFinanceId);
        }

        protected override IQueryable<CustomerFinancePropertyValueModel> JoinProperty(IQueryable<CustomerFinancePropertyValueEntity> values, IQueryable<CustomerFinancePropertyEntity> properties)
        {
            var query = from value in values
                        join property in properties on value.PropertyId equals property.Id
                        select new CustomerFinancePropertyValueModel
                        {
                            CreateTime = value.CreateTime,
                            SubscriberId = value.SubscriberId,
                            CustomerFinanceId = value.CustomerFinanceId,
                            Id = value.Id,
                            PropertyId = value.PropertyId,
                            Value = value.Value,
                            IsTableColumn = property.IsTableColumn,
                            PropertyName = property.Name,
                            Type = property.Type,
                        };
            return query;
        }
    }
}
