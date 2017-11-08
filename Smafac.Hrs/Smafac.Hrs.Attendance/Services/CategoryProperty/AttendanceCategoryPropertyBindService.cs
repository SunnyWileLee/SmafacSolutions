using Smafac.Framework.Core.Repositories.CategoryProperty;
using Smafac.Framework.Core.Services.CategoryProperty;
using Smafac.Hrs.Attendance.Applications.CategoryProperty;
using Smafac.Hrs.Attendance.Domain;
using Smafac.Hrs.Attendance.Domain.CategoryProperty;
using Smafac.Hrs.Attendance.Repositories.Category;
using Smafac.Hrs.Attendance.Repositories.CategoryProperty;
using Smafac.Hrs.Attendance.Repositories.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Attendance.Services.CategoryProperty
{
    class AttendanceCategoryPropertyBindService : CategoryPropertyBindService<AttendanceCategoryEntity, AttendancePropertyEntity>,
                                        IAttendanceCategoryPropertyBindService
    {
        public AttendanceCategoryPropertyBindService(IAttendanceCategoryPropertyBindRepository categoryPropertyBindRepository,
                                                IAttendanceCategoryPropertySearchRepository categoryPropertySearchRepository,
                                                IEnumerable<IAttendanceCategoryPropertyBindTrigger> categoryPropertyBindTriggers,
                                                IAttendanceCategorySearchRepository categorySearchRepository,
                                                IAttendancePropertySearchRepository propertySearchRepository
                                                )
        {
            base.EntityAssociationBindRepository = categoryPropertyBindRepository;
            base.EntityAssociationSearchRepository = categoryPropertySearchRepository;
            base.CategoryAssociationBindTriggers = categoryPropertyBindTriggers;
            base.CategorySearchRepository = categorySearchRepository;
            base.AssociationSearchRepository = propertySearchRepository;
        }
    }
}
