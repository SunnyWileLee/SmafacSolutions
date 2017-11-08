using Smafac.Framework.Core.Domain.Property;
using Smafac.Hrs.Attendance.Repositories.CategoryProperty;

namespace Smafac.Hrs.Attendance.Domain.Property
{
    class CustomerPropertyDeleteCategoryTrigger : PropertyDeleteCategoryTrigger<AttendanceCategoryEntity, AttendancePropertyEntity, AttendanceCategoryPropertyEntity>,
        IAttendancePropertyDeleteTrigger
    {
        public CustomerPropertyDeleteCategoryTrigger(IAttendanceCategoryPropertyBindRepository categoryPropertyBindRepository)
        {
            base.CategoryPropertyBindRepository = categoryPropertyBindRepository;
        }
    }
}
