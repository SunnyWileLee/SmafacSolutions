using Smafac.Framework.Core.Repositories.PropertyValue;
using Smafac.Hrs.Employee.Domain;
using Smafac.Hrs.Employee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Smafac.Hrs.Employee.Repositories.PropertyValue
{
    class EmployeePropertyValueSearchRepository : PropertyValueSearchRepository<EmployeeContext, EmployeePropertyValueEntity, EmployeePropertyEntity, EmployeePropertyValueModel>
                                                , IEmployeePropertyValueSearchRepository
    {
        public EmployeePropertyValueSearchRepository(IEmployeeContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }

        protected override Expression<Func<EmployeePropertyValueEntity, bool>> CreateEntityQueryExpression(Guid entityId)
        {
            return s => s.EmployeeId.Equals(entityId);
        }

        protected override Expression<Func<EmployeePropertyValueEntity, bool>> CreateEntityQueryExpression(IEnumerable<Guid> entityIds)
        {
            return s => entityIds.Contains(s.EmployeeId);
        }

        protected override IEnumerable<IGrouping<Guid, EmployeePropertyValueModel>> GroupValues(IEnumerable<EmployeePropertyValueModel> values)
        {
            return values.GroupBy(s => s.EmployeeId);
        }

        protected override IQueryable<EmployeePropertyValueModel> JoinProperty(IQueryable<EmployeePropertyValueEntity> values, IQueryable<EmployeePropertyEntity> properties)
        {
            var query = from value in values
                        join property in properties on value.PropertyId equals property.Id
                        select new EmployeePropertyValueModel
                        {
                            CreateTime = value.CreateTime,
                            SubscriberId = value.SubscriberId,
                            EmployeeId = value.EmployeeId,
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
