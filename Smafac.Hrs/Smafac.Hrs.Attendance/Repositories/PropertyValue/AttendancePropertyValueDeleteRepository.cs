using Smafac.Framework.Core.Repositories.PropertyValue;
using Smafac.Hrs.Attendance.Domain;

namespace Smafac.Hrs.Attendance.Repositories.PropertyValue
{
    class AttendancePropertyValueDeleteRepository : PropertyValueDeleteRepository<AttendanceContext, AttendancePropertyValueEntity>,
                                                IAttendancePropertyValueDeleteRepository
    {

        public AttendancePropertyValueDeleteRepository(IAttendanceContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}
