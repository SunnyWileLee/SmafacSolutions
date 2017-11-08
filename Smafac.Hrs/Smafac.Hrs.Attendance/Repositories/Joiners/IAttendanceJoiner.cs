using Smafac.Hrs.Attendance.Domain;
using Smafac.Hrs.Attendance.Models;
using System.Linq;

namespace Smafac.Hrs.Attendance.Repositories.Joiners
{
    interface IAttendanceJoiner
    {
        IQueryable<AttendanceModel> Join(IQueryable<AttendanceEntity> goodses, IQueryable<AttendanceCategoryEntity> categories);
    }
}
