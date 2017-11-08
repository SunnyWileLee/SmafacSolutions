using Smafac.Framework.Core.Domain.Property;
using Smafac.Hrs.Attendance.Repositories.CategoryProperty;

namespace Smafac.Hrs.Attendance.Domain.Property
{
    class AttendancePropertyUsedByCategoryChecker : PropertyUsedByCategoryChecker<AttendanceCategoryEntity, AttendancePropertyEntity>,
                                                IAttendancePropertyUsedChecker
    {
        public AttendancePropertyUsedByCategoryChecker(IAttendanceCategoryPropertySearchRepository goodsategoryPropertySearchRepository)
        {
            base.CategoryPropertySearchRepository = goodsategoryPropertySearchRepository;
        }
    }
}
