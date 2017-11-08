using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Attendance.Models
{
    public class AttendanceDetailModel : SaasBaseModel
    {
        public AttendanceModel Attendance { get; set; }
    }
}
