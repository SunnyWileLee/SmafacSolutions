using Smafac.Hrs.Attendance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Attendance.Applications
{
    public interface IAttendanceService
    {
        IAttendanceUpdateService UpdateService { get; set; }
        bool AddAttendance(AttendanceModel model);
        AttendanceModel CreateEmptyAttendance();
    }
}
