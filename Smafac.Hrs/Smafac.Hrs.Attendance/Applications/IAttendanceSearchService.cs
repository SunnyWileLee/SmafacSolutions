using Smafac.Framework.Core.Models;
using Smafac.Hrs.Attendance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Attendance.Applications
{
    public interface IAttendanceSearchService
    {
        AttendanceModel GetAttendance(Guid goodsId);
        AttendanceDetailModel GetAttendanceDetail(Guid goodsId);
        PageModel<AttendanceModel> GetAttendancePage(AttendancePageQueryModel query);
        List<AttendanceModel> GetAttendance(AttendancePageQueryModel query);
        List<AttendanceModel> GetAttendance(IEnumerable<Guid> goodsIds);
    }
}
