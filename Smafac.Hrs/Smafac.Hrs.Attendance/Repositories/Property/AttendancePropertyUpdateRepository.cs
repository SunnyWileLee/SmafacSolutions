using Smafac.Framework.Core.Repositories.Property;
using Smafac.Hrs.Attendance.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Attendance.Repositories.Property
{
    class AttendancePropertyUpdateRepository : PropertyUpdateRepository<AttendanceContext, AttendancePropertyEntity>, IAttendancePropertyUpdateRepository
    {
        public AttendancePropertyUpdateRepository(IAttendanceContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}
