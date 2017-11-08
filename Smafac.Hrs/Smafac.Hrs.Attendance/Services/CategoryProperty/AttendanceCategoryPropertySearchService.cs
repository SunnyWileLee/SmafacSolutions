using Smafac.Framework.Core.Services.CategoryProperty;
using Smafac.Hrs.Attendance.Applications.CategoryProperty;
using Smafac.Hrs.Attendance.Domain;
using Smafac.Hrs.Attendance.Domain.CategoryProperty;
using Smafac.Hrs.Attendance.Models;
using Smafac.Hrs.Attendance.Repositories.CategoryProperty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Attendance.Services.CategoryProperty
{
    class AttendanceCategoryPropertySearchService : CategoryPropertySearchService<AttendanceCategoryEntity, AttendancePropertyEntity, AttendancePropertyModel>,
                                                IAttendanceCategoryPropertySearchService
    {
        public AttendanceCategoryPropertySearchService(IAttendanceCategoryPropertySearchRepository categoryPropertySearchRepository,
            IAttendanceCategoryPropertyProvider categoryPropertyProvider
            )
        {
            base.CategoryAssociationProvider = categoryPropertyProvider;
            base.EntityAssociationSearchRepository = categoryPropertySearchRepository;
        }
    }
}
