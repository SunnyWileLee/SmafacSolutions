using Smafac.Framework.Core.Repositories.PropertyValue;
using Smafac.Hrs.Attendance.Domain;
using System;
using System.Linq;

namespace Smafac.Hrs.Attendance.Repositories.PropertyValue
{
    class AttendancePropertyValueSetRepository : PropertyValueSetRepository<AttendanceContext, AttendancePropertyValueEntity>
                                                , IAttendancePropertyValueSetRepository
    {
        public AttendancePropertyValueSetRepository(IAttendanceContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }

        protected override bool HasSetValue(IQueryable<AttendancePropertyValueEntity> values, Guid entityId)
        {
            return values.Any(s => s.AttendanceId.Equals(entityId));
        }

        protected override bool VerifyEntityId(Guid entityId, AttendancePropertyValueEntity value)
        {
            return !entityId.Equals(value.AttendanceId);
        }
    }
}
