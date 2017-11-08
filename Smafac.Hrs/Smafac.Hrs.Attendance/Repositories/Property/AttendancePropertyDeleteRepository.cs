﻿using Smafac.Framework.Core.Repositories.Property;
using Smafac.Hrs.Attendance.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Attendance.Repositories.Property
{
    class AttendancePropertyDeleteRepository : PropertyDeleteRepository<AttendanceContext, AttendancePropertyEntity>, IAttendancePropertyDeleteRepository
    {
        public AttendancePropertyDeleteRepository(IAttendanceContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}
