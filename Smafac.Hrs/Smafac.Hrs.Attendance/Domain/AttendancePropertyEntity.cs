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
    [Table("AttendanceProperty")]
    class AttendancePropertyEntity : PropertyEntity
    {
        public AttendancePropertyValueEntity CreateEmptyValue()
        {
            return this.CreateValue(Guid.Empty, string.Empty);
        }

        public AttendancePropertyValueEntity CreateValue(Guid goodsId, string value)
        {
            var propertyValue = base.CreateValueBase<AttendancePropertyValueEntity>(value);
            propertyValue.AttendanceId = goodsId;
            return propertyValue;
        }
    }
}
