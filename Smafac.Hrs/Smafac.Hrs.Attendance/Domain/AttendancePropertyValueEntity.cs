using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Attendance.Domain
{
    [Table("AttendancePropertyValue")]
    class AttendancePropertyValueEntity : PropertyValueEntity
    {
        public Guid AttendanceId { get; set; }
    }
}
