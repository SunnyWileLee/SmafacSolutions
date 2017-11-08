using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Employee.Domain
{
    [Table("EmployeeProperty")]
    class EmployeePropertyEntity : PropertyEntity
    {
        public EmployeePropertyValueEntity CreateEmptyValue()
        {
            return this.CreateValue(Guid.Empty, string.Empty);
        }

        public EmployeePropertyValueEntity CreateValue(Guid goodsId, string value)
        {
            var propertyValue = base.CreateValueBase<EmployeePropertyValueEntity>(value);
            propertyValue.EmployeeId = goodsId;
            return propertyValue;
        }
    }
}
