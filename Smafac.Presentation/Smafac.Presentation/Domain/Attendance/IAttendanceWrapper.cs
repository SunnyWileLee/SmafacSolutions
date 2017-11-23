using Smafac.Hrs.Attendance.Models;
using System.Collections.Generic;

namespace Smafac.Presentation.Domain.Attendance
{
    public interface IAttendanceWrapper
    {
        void Wrapper(List<AttendanceModel> attendances);
    }
}
