using Smafac.Hrs.Attendance.Applications.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Hrs.Attendance.Models;
using Smafac.Framework.Core.Services.Property;
using Smafac.Hrs.Attendance.Domain;
using Smafac.Hrs.Attendance.Repositories.Property;

namespace Smafac.Hrs.Attendance.Services.Property
{
    class AttendancePropertyAddService : PropertyAddService<AttendancePropertyEntity, AttendancePropertyModel>, IAttendancePropertyAddService
    {
        public AttendancePropertyAddService(IAttendancePropertyAddRepository propertyAddRepository,
                                        IAttendancePropertySearchRepository propertySearchRepository)
        {
            base.CustomizedColumnAddRepository = propertyAddRepository;
            base.CustomizedColumnSearchRepository = propertySearchRepository;
        }
    }
}
