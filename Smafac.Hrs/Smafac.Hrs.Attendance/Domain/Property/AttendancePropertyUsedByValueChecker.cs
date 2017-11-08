using Smafac.Framework.Core.Domain.Property;
using Smafac.Hrs.Attendance.Models;
using Smafac.Hrs.Attendance.Repositories.PropertyValue;

namespace Smafac.Hrs.Attendance.Domain.Property
{
    class AttendancePropertyUsedByValueChecker : PropertyUsedByValueChecker<AttendancePropertyEntity, AttendancePropertyValueModel>,
                                                IAttendancePropertyUsedChecker
    {
        public AttendancePropertyUsedByValueChecker(IAttendancePropertyValueSearchRepository propertyValueSearchRepository)
        {
            base.PropertyValueSearchRepository = propertyValueSearchRepository;
        }
    }
}
