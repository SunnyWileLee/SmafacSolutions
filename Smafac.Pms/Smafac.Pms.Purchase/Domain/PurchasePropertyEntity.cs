using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Pms.Purchase.Domain
{
    [Table("PurchaseProperty")]
    class PurchasePropertyEntity : PropertyEntity
    {
        public PurchasePropertyValueEntity CreateEmptyValue()
        {
            return this.CreateValue(Guid.Empty, string.Empty);
        }

        public PurchasePropertyValueEntity CreateValue(Guid goodsId, string value)
        {
            var propertyValue = base.CreateValueBase<PurchasePropertyValueEntity>(value);
            propertyValue.PurchaseId = goodsId;
            return propertyValue;
        }
    }
}
