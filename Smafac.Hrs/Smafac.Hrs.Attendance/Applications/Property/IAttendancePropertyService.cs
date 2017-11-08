using Smafac.Framework.Core.Applications.Property;
using Smafac.Hrs.Attendance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Attendance.Applications.Property
{
    public interface IAttendancePropertyService 
    {
        IAttendancePropertyAddService AddService { get; set; }
        IAttendancePropertyDeleteService DeleteService { get; set; }
        IAttendancePropertySearchService SearchService { get; set; }
        IAttendancePropertyUpdateService UpdateService { get; set; }
    }
}
