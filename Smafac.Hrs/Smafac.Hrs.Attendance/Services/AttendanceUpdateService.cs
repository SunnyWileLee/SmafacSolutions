using Smafac.Hrs.Attendance.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Hrs.Attendance.Models;
using Smafac.Hrs.Attendance.Repositories;
using AutoMapper;
using Smafac.Hrs.Attendance.Domain;
using Smafac.Framework.Core.Models;
using Smafac.Hrs.Attendance.Repositories.PropertyValue;

namespace Smafac.Hrs.Attendance.Services
{
    class AttendanceUpdateService : IAttendanceUpdateService
    {
        private readonly IAttendanceUpdateRepository _attendanceUpdateRepository;
        private readonly IAttendancePropertyValueSetRepository _propertyValueSetRepository;

        public AttendanceUpdateService(IAttendanceUpdateRepository attendanceUpdateRepository,
                                    IAttendancePropertyValueSetRepository propertyValueSetRepository)
        {
            _attendanceUpdateRepository = attendanceUpdateRepository;
            _propertyValueSetRepository = propertyValueSetRepository;
        }

        public bool UpdateAttendance(AttendanceModel model)
        {
            var attendance = Mapper.Map<AttendanceEntity>(model);
            attendance.SubscriberId = UserContext.Current.SubscriberId;
            var update = _attendanceUpdateRepository.UpdateEntity(attendance);

            if (update && model.HasProperties)
            {
                model.Properties.ForEach(property =>
                {
                    property.AttendanceId = attendance.Id;
                    property.SubscriberId = attendance.SubscriberId;
                    var value = Mapper.Map<AttendancePropertyValueEntity>(property);
                    update &= _propertyValueSetRepository.SetPropertyValue(value);
                });
            }
            return update;
        }
    }
}
