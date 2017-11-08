using Smafac.Framework.Core.Domain.EntityAssociationProviders;
using Smafac.Hrs.Attendance.Models;
using Smafac.Hrs.Attendance.Repositories.Category;
using Smafac.Hrs.Attendance.Repositories.CategoryProperty;

namespace Smafac.Hrs.Attendance.Domain.CategoryProperty
{
    class AttendanceCategoryPropertyProvider : CategoryPropertyProvider<AttendanceCategoryEntity, AttendancePropertyEntity, AttendancePropertyModel>,
                                            IAttendanceCategoryPropertyProvider
    {

        public AttendanceCategoryPropertyProvider(IAttendanceCategoryPropertySearchRepository categoryPropertySearchRepository,
                                            IAttendanceCategorySearchRepository categorySearchRepository)
        {
            base.CategorySearchRepository = categorySearchRepository;
            base.CategoryAssociationSearchRepository = categoryPropertySearchRepository;
        }
    }
}
