using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Attendance.Repositories
{
    class AttendanceContextProvider : IAttendanceContextProvider
    {
        public AttendanceContext Provide()
        {
            return new AttendanceContext();
        }

        public AttendanceContext ProvideSlave()
        {
            return new AttendanceContext();
        }
    }
}
