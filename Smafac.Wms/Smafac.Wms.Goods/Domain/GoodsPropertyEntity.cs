using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Domain
{
    [Table("GoodsProperty")]
    class GoodsPropertyEntity : PropertyEntity
    {
        public GoodsPropertyValueEntity CreateEmptyValue()
        {
            return this.CreateValue(Guid.Empty, string.Empty);
        }

        public GoodsPropertyValueEntity CreateValue(Guid goodsId, string value)
        {
            var propertyValue = base.CreateValueBase<GoodsPropertyValueEntity>(value);
            propertyValue.GoodsId = goodsId;
            return propertyValue;
        }
    }
}
