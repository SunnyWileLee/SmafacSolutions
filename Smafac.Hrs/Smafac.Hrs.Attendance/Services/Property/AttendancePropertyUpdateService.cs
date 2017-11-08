using Smafac.Framework.Core.Services.Property;
using Smafac.Hrs.Attendance.Applications.Property;
using Smafac.Hrs.Attendance.Domain;
using Smafac.Hrs.Attendance.Models;
using Smafac.Hrs.Attendance.Repositories.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Attendance.Services.Property
{
    class AttendancePropertyUpdateService : PropertyUpdateService<AttendancePropertyEntity, AttendancePropertyModel>, IAttendancePropertyUpdateService
    {
        public AttendancePropertyUpdateService(IAttendancePropertySearchRepository propertySearchRepository,
                                          IAttendancePropertyUpdateRepository propertyUpdateRepository)
        {
            base.CustomizedColumnSearchRepository = propertySearchRepository;
            base.CustomizedColumnUpdateRepository = propertyUpdateRepository;
        }
    }
}
