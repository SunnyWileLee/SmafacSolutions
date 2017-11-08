using Smafac.Framework.Core.Domain.Property;
using Smafac.Hrs.Attendance.Repositories.PropertyValue;

namespace Smafac.Hrs.Attendance.Domain.Property
{
    class CustomerPropertyDeleteValueTrigger : PropertyDeleteValueTrigger<AttendancePropertyEntity, AttendancePropertyValueEntity>,
                                            IAttendancePropertyDeleteTrigger
    {
        public CustomerPropertyDeleteValueTrigger(IAttendancePropertyValueDeleteRepository propertyValueDeleteRepository)
        {
            base.PropertyValueDeleteRepository = propertyValueDeleteRepository;
        }
    }
}
