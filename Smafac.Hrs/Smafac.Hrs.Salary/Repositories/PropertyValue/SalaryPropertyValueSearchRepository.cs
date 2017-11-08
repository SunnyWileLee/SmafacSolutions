using Smafac.Framework.Core.Repositories.PropertyValue;
using Smafac.Hrs.Salary.Domain;
using Smafac.Hrs.Salary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Smafac.Hrs.Salary.Repositories.PropertyValue
{
    class SalaryPropertyValueSearchRepository : PropertyValueSearchRepository<SalaryContext, SalaryPropertyValueEntity, SalaryPropertyEntity, SalaryPropertyValueModel>
                                                , ISalaryPropertyValueSearchRepository
    {
        public SalaryPropertyValueSearchRepository(ISalaryContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }

        protected override Expression<Func<SalaryPropertyValueEntity, bool>> CreateEntityQueryExpression(Guid entityId)
        {
            return s => s.SalaryId.Equals(entityId);
        }

        protected override Expression<Func<SalaryPropertyValueEntity, bool>> CreateEntityQueryExpression(IEnumerable<Guid> entityIds)
        {
            return s => entityIds.Contains(s.SalaryId);
        }

        protected override IEnumerable<IGrouping<Guid, SalaryPropertyValueModel>> GroupValues(IEnumerable<SalaryPropertyValueModel> values)
        {
            return values.GroupBy(s => s.SalaryId);
        }

        protected override IQueryable<SalaryPropertyValueModel> JoinProperty(IQueryable<SalaryPropertyValueEntity> values, IQueryable<SalaryPropertyEntity> properties)
        {
            var query = from value in values
                        join property in properties on value.PropertyId equals property.Id
                        select new SalaryPropertyValueModel
                        {
                            CreateTime = value.CreateTime,
                            SubscriberId = value.SubscriberId,
                            SalaryId = value.SalaryId,
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
