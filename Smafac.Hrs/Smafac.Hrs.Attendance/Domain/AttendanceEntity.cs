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
    [Table("Attendance")]
    class AttendanceEntity : SaasBaseEntity
    {
        public AttendanceEntity()
        {
            BeginTime = DateTime.Now.Date.AddHours(8);
            BeginTime = DateTime.Now.Date.AddHours(17);
        }
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid CategoryId { get; set; }
    }
}
