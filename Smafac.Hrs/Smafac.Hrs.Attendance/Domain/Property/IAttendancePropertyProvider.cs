using Smafac.Framework.Core.Models;
using Smafac.Hrs.Attendance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Attendance.Domain.Property
{
    interface IAttendancePropertyProvider
    {
        List<AttendancePropertyModel> Provide(Guid goodsId);
    }
}
