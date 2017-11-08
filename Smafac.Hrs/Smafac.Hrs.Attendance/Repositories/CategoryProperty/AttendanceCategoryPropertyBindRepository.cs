using Smafac.Framework.Core.Repositories.CategoryProperty;
using Smafac.Hrs.Attendance.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Attendance.Repositories.CategoryProperty
{
    class AttendanceCategoryPropertyBindRepository : CategoryPropertyBindRepository<AttendanceContext, AttendanceCategoryEntity, AttendancePropertyEntity, AttendanceCategoryPropertyEntity>,
                                                IAttendanceCategoryPropertyBindRepository
    {
        public AttendanceCategoryPropertyBindRepository(IAttendanceContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}
