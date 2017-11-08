using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Salary.Domain
{
    [Table("SalaryProperty")]
    class SalaryPropertyEntity : PropertyEntity
    {
        public SalaryPropertyValueEntity CreateEmptyValue()
        {
            return this.CreateValue(Guid.Empty, string.Empty);
        }

        public SalaryPropertyValueEntity CreateValue(Guid goodsId, string value)
        {
            var propertyValue = base.CreateValueBase<SalaryPropertyValueEntity>(value);
            propertyValue.SalaryId = goodsId;
            return propertyValue;
        }
    }
}
