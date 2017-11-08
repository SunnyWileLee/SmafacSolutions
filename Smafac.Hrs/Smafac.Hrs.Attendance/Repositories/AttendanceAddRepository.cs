using Smafac.Framework.Core.Repositories;
using Smafac.Hrs.Attendance.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Attendance.Repositories
{
    class AttendanceAddRepository : EntityAddRepository<AttendanceContext, AttendanceEntity>, IAttendanceAddRepository
    {
        public AttendanceAddRepository(IAttendanceContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}
