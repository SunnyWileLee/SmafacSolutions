using Smafac.Framework.Core.Repositories;
using Smafac.Hrs.Attendance.Domain;
using Smafac.Hrs.Attendance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Attendance.Repositories
{
    interface IAttendanceSearchRepository : IEntitySearchRepository<AttendanceEntity>
    {
        AttendanceModel GetAttendance(Guid subscriberId, Guid goodsId);
        List<AttendanceModel> GetAttendance(Guid subscriberId, Expression<Func<AttendanceEntity, bool>> predicate);
    }
}
