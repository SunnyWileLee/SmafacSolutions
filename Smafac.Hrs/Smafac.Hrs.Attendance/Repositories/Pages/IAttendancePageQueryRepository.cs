using Smafac.Framework.Core.Repositories.Pages;
using Smafac.Hrs.Attendance.Domain;
using Smafac.Hrs.Attendance.Models;

namespace Smafac.Hrs.Attendance.Repositories.Pages
{
    interface IAttendancePageQueryRepository : IPageQueryRepository<AttendanceEntity, AttendanceModel>
    {

    }
}
