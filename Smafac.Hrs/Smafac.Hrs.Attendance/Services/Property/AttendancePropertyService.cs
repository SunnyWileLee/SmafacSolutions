using Smafac.Hrs.Attendance.Applications.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Framework.Core.Applications.Property;
using Smafac.Hrs.Attendance.Models;

namespace Smafac.Hrs.Attendance.Services.Property
{
    class AttendancePropertyService : IAttendancePropertyService
    {
        public AttendancePropertyService(IAttendancePropertyAddService propertyAddService,
            IAttendancePropertyDeleteService propertyDeleteService,
            IAttendancePropertySearchService propertySearchService,
            IAttendancePropertyUpdateService propertyUpdateService)
        {
            AddService = propertyAddService;
            DeleteService = propertyDeleteService;
            SearchService = propertySearchService;
            UpdateService = propertyUpdateService;
        }

        public IAttendancePropertyAddService AddService { get; set; }
        public IAttendancePropertyDeleteService DeleteService { get; set; }
        public IAttendancePropertySearchService SearchService { get; set; }
        public IAttendancePropertyUpdateService UpdateService { get; set; }
    }
}
