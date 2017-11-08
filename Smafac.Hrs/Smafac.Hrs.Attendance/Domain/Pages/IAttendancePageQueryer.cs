using Smafac.Framework.Core.Domain.Pages;
using Smafac.Hrs.Attendance.Models;

namespace Smafac.Hrs.Attendance.Domain.Pages
{
    interface IAttendancePageQueryer : IPageQueryer<AttendanceModel, AttendancePageQueryModel>
    {
    }
}
