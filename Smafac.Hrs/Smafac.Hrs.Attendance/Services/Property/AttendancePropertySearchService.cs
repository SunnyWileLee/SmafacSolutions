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
    class AttendancePropertySearchService : PropertySearchService<AttendancePropertyEntity, AttendancePropertyModel>, IAttendancePropertySearchService
    {
        private readonly IAttendancePropertyProvider _propertyProvider;

        public AttendancePropertySearchService(IAttendancePropertySearchRepository searchRepository,
            IAttendancePropertyProvider propertyProvider)
        {
            base.CustomizedColumnSearchRepository = searchRepository;
            _propertyProvider = propertyProvider;
        }

        public override List<AttendancePropertyModel> GetColumns(Guid entityId)
        {
            return _propertyProvider.Provide(entityId);
        }
    }
}
