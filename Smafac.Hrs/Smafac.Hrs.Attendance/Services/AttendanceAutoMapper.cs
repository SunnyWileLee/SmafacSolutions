using AutoMapper;
using Smafac.Framework.Core.Models;
using Smafac.Hrs.Attendance.Domain;
using Smafac.Hrs.Attendance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Attendance.Services
{
    class AttendanceAutoMapper : SmafacAutoMapper
    {
        public override void CreateMapper(IMapperConfigurationExpression cfg)
        {
            base.BipassMapper<AttendanceEntity, AttendanceModel>(cfg);
            base.BipassMapper<AttendancePropertyEntity, AttendancePropertyModel>(cfg);
            base.BipassMapper<AttendancePropertyValueEntity, AttendancePropertyValueModel>(cfg);
            base.BipassMapper<AttendanceCategoryEntity, AttendanceCategoryModel>(cfg);
        }
    }
}
