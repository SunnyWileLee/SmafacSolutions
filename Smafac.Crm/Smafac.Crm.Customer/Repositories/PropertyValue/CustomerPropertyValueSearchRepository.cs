using Smafac.Crm.Customer.Domain;
using Smafac.Crm.Customer.Models;
using Smafac.Framework.Core.Repositories.PropertyValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Framework.Core.Domain;
using System.Linq.Expressions;

namespace Smafac.Crm.Customer.Repositories.PropertyValue
{
    class CustomerPropertyValueSearchRepository : PropertyValueSearchRepository<CustomerContext, CustomerPropertyValueEntity, CustomerPropertyEntity, CustomerPropertyValueModel>
                                                , ICustomerPropertyValueSearchRepository
    {
        public CustomerPropertyValueSearchRepository(ICustomerContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }

        protected override Expression<Func<CustomerPropertyValueEntity, bool>> CreateEntityQueryExpression(Guid entityId)
        {
            return s => s.CustomerId.Equals(entityId);
        }

        protected override Expression<Func<CustomerPropertyValueEntity, bool>> CreateEntityQueryExpression(IEnumerable<Guid> entityIds)
        {
            return s => entityIds.Contains(s.CustomerId);
        }

        protected override IEnumerable<IGrouping<Guid, CustomerPropertyValueModel>> GroupValues(IEnumerable<CustomerPropertyValueModel> values)
        {
            return values.GroupBy(s => s.CustomerId);
        }

        protected override IQueryable<CustomerPropertyValueModel> JoinProperty(IQueryable<CustomerPropertyValueEntity> values, IQueryable<CustomerPropertyEntity> properties)
        {
            var query = from value in values
                        join property in properties on value.PropertyId equals property.Id
                        select new CustomerPropertyValueModel
                        {
                            CreateTime = value.CreateTime,
                            SubscriberId = value.SubscriberId,
                            CustomerId = value.CustomerId,
                            Id = value.Id,
                            PropertyId = value.PropertyId,
                            Value = value.Value,
                            IsTableColumn = property.IsTableColumn,
                            PropertyName = property.Name,
                            Type = property.Type
                        };
            return query;
        }
    }
}
