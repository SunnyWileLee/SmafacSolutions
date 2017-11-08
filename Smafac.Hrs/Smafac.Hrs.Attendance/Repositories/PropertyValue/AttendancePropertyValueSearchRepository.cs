using Smafac.Framework.Core.Repositories.PropertyValue;
using Smafac.Hrs.Attendance.Domain;
using Smafac.Hrs.Attendance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Smafac.Hrs.Attendance.Repositories.PropertyValue
{
    class AttendancePropertyValueSearchRepository : PropertyValueSearchRepository<AttendanceContext, AttendancePropertyValueEntity, AttendancePropertyEntity, AttendancePropertyValueModel>
                                                , IAttendancePropertyValueSearchRepository
    {
        public AttendancePropertyValueSearchRepository(IAttendanceContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }

        protected override Expression<Func<AttendancePropertyValueEntity, bool>> CreateEntityQueryExpression(Guid entityId)
        {
            return s => s.AttendanceId.Equals(entityId);
        }

        protected override Expression<Func<AttendancePropertyValueEntity, bool>> CreateEntityQueryExpression(IEnumerable<Guid> entityIds)
        {
            return s => entityIds.Contains(s.AttendanceId);
        }

        protected override IEnumerable<IGrouping<Guid, AttendancePropertyValueModel>> GroupValues(IEnumerable<AttendancePropertyValueModel> values)
        {
            return values.GroupBy(s => s.AttendanceId);
        }

        protected override IQueryable<AttendancePropertyValueModel> JoinProperty(IQueryable<AttendancePropertyValueEntity> values, IQueryable<AttendancePropertyEntity> properties)
        {
            var query = from value in values
                        join property in properties on value.PropertyId equals property.Id
                        select new AttendancePropertyValueModel
                        {
                            CreateTime = value.CreateTime,
                            SubscriberId = value.SubscriberId,
                            AttendanceId = value.AttendanceId,
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
