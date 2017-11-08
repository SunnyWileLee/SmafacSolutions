using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Hrs.Attendance.Models;
using Smafac.Framework.Core.Repositories;
using Smafac.Hrs.Attendance.Domain;

namespace Smafac.Hrs.Attendance.Repositories
{
    class AttendanceUpdateRepository : EntityUpdateRepository<AttendanceContext, AttendanceEntity>,
                                    IAttendanceUpdateRepository
    {
        public AttendanceUpdateRepository(IAttendanceContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }

        protected override void SetValue(AttendanceEntity entity, AttendanceEntity source)
        {
            entity.BeginTime = source.BeginTime;
            entity.EndTime = source.EndTime;
        }
    }
}
