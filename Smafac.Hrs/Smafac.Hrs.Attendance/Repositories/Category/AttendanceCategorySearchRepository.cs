using Smafac.Framework.Core.Repositories.Category;
using Smafac.Hrs.Attendance.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Attendance.Repositories.Category
{
    class AttendanceCategorySearchRepository : CategorySearchRepository<AttendanceContext, AttendanceCategoryEntity>, IAttendanceCategorySearchRepository
    {
        public AttendanceCategorySearchRepository(IAttendanceContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}
