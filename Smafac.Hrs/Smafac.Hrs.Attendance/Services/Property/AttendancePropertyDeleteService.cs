using Smafac.Framework.Core.Services.Property;
using Smafac.Hrs.Attendance.Applications.Property;
using Smafac.Hrs.Attendance.Domain;
using Smafac.Hrs.Attendance.Domain.Property;
using Smafac.Hrs.Attendance.Models;
using Smafac.Hrs.Attendance.Repositories.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Attendance.Services.Property
{
    class AttendancePropertyDeleteService : PropertyDeleteService<AttendancePropertyEntity, AttendancePropertyModel>, IAttendancePropertyDeleteService
    {
        public AttendancePropertyDeleteService(IAttendancePropertyDeleteRepository propertyDeleteRepository,
                                          IAttendancePropertySearchRepository propertySearchRepository,
                                          IAttendancePropertyUsedChecker[] goodsFinancePropertyUsedCheckers,
                                          IAttendancePropertyDeleteTrigger[] propertyDeleteTriggers)
        {
            base.CustomizedColumnDeleteRepository = propertyDeleteRepository;
            base.CustomizedColumnUsedCheckers = goodsFinancePropertyUsedCheckers;
            base.CustomizedColumnSearchRepository = propertySearchRepository;
            base.CustomizedColumnDeleteTriggers = propertyDeleteTriggers;
        }
    }
}
